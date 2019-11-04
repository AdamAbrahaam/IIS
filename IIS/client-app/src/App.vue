<template>
  <v-app id="inspire">
    <v-app-bar flat max-height="65px" color="#252423">
      <v-app-bar-nav-icon
        class="hidden-md-and-up"
        @click.stop="drawer = !drawer"
      ></v-app-bar-nav-icon>

      <v-btn class="hidden-sm-and-down logo-btn" text color="#e7e6e3" to="/">
        <span id="title" class="mr-2 display-1">Fifka</span>
      </v-btn>
      <v-spacer></v-spacer>

      <v-btn class="hidden-sm-and-down" text color="#e7e6e3" to="/tournaments">
        <span>Tournaments</span>
      </v-btn>

      <v-btn class=" hidden-sm-and-down" text color="#e7e6e3" to="/rankings">
        <span>Rankings</span>
      </v-btn>

      <div v-if="currentUser.email">
        <v-menu close-on-content-click offset-y>
          <template v-slot:activator="{ on }">
            <v-btn
              class="white--text hidden-sm-and-down"
              text
              color="#e7e6e3"
              v-on="on"
            >
              <span>Create<v-icon>mdi-chevron-down</v-icon></span>
            </v-btn>
          </template>

          <v-list>
            <v-list-item-group>
              <v-list-item
                v-for="(item, index) in createOptions"
                :key="index"
                @click="item.callback"
              >
                <v-list-item-icon>
                  <v-icon v-text="item.icon"></v-icon>
                </v-list-item-icon>
                <v-list-item-content>
                  <v-list-item-title>{{ item.text }}</v-list-item-title>
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        </v-menu>

        <v-menu close-on-content-click offset-y>
          <template v-slot:activator="{ on }">
            <v-avatar
              color="#3bf8f7"
              size="44"
              v-on="on"
              class="mx-5"
              style="cursor: pointer"
            >
              <span class="#1a2430--text headline">{{
                currentUser.firstName[0]
              }}</span>
            </v-avatar>
          </template>

          <v-list>
            <v-list-item-group>
              <v-list-item
                v-for="(item, index) in profileOptions"
                :key="index"
                @click="item.callback"
              >
                <v-list-item-content>
                  <v-list-item-title>{{ item.text }}</v-list-item-title>
                </v-list-item-content>
                <v-list-item-icon>
                  <v-icon v-text="item.icon"></v-icon>
                </v-list-item-icon>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        </v-menu>
      </div>
      <div v-else>
        <v-btn
          class="white--text hidden-sm-and-down mx-5 "
          outlined
          color="#e7e6e3"
          @click.stop="loginDialog = true"
        >
          <span>Login</span>
        </v-btn>
      </div>
    </v-app-bar>

    <v-dialog v-model="loginDialog" overlay-opacity="0.8" max-width="600px">
      <LoginPanel v-bind:closeModal="closeModal" />
    </v-dialog>
    <v-dialog
      v-model="tournamentPanelShowing"
      persistent
      overlay-opacity="0.8"
      max-width="600px"
    >
      <TournamentPanel
        v-bind:editInfo="tournament"
        v-bind:isEditing="isEditing"
      />
    </v-dialog>
    <v-dialog
      v-model="profilePanelShowing"
      persistent
      overlay-opacity="0.8"
      max-width="600px"
    >
      <ProfilePanel />
    </v-dialog>
    <v-dialog
      v-model="teamPanelShowing"
      persistent
      overlay-opacity="0.8"
      max-width="600px"
    >
      <TeamPanel v-bind:editInfo="tournament" v-bind:isEditing="isEditing" />
    </v-dialog>
    <v-dialog
      v-model="teamProfilePanelShowing"
      persistent
      overlay-opacity="0.8"
      max-width="600px"
    >
      <TeamProfile />
    </v-dialog>

    <v-navigation-drawer
      id="drawer"
      v-model="drawer"
      temporary
      absolute
      width="100vw"
    ></v-navigation-drawer>

    <v-content>
      <router-view />
    </v-content>

    <v-footer padless color="#252423">
      <v-col class="text-center white--text" cols="12">
        <strong> {{ new Date().getFullYear() }} VUT FIT IIS </strong> - Adam
        Abrahám, Tomáš Žigo, Adrián Boros
      </v-col>
    </v-footer>
  </v-app>
</template>

<script>
import { mapState } from "vuex";
import LoginPanel from "@/components/LoginPanel.vue";
import TournamentPanel from "@/components/TournamentPanel.vue";
import ProfilePanel from "@/components/ProfilePanel.vue";
import TeamPanel from "@/components/TeamPanel.vue";
import TeamProfile from "@/components/TeamProfile.vue";

export default {
  name: "App",
  components: {
    LoginPanel,
    TournamentPanel,
    ProfilePanel,
    TeamPanel,
    TeamProfile
  },
  data() {
    return {
      drawer: null,
      loginDialog: false,
      profileOptions: [
        {
          text: "My Profile",
          icon: "mdi-account",
          callback: () =>
            this.$store.dispatch("panels/setPanel", {
              show: true,
              panel: "profilePanel",
              profileId: this.currentUser.userId
            })
        },
        {
          text: "My Team",
          icon: "mdi-account-multiple",
          callback: () =>
            this.$store.dispatch("panels/setPanel", {
              show: true,
              panel: "teamProfilePanel",
              teamName: this.currentUser.team.name
            })
        },
        { text: "Logout", icon: "mdi-logout", callback: () => this.logout() }
      ],
      createOptions: [
        {
          text: "Tournament",
          icon: "mdi-trophy-variant",
          callback: () =>
            this.$store.dispatch("panels/setPanel", {
              show: true,
              panel: "tournamentPanel",
              profileId: null
            })
        },
        {
          text: "Team",
          icon: "mdi-account-multiple",
          callback: () =>
            this.$store.dispatch("panels/setPanel", {
              show: true,
              panel: "teamPanel",
              profileId: null
            })
        }
      ]
    };
  },

  created() {
    this.$store.dispatch("tournaments/getAll");
  },

  computed: {
    ...mapState({
      currentUser: state => state.user.currentUser,
      tournament: state => state.tournaments.tournament,
      isEditing: state => state.tournaments.editing,
      tournamentPanelShowing: state => state.panels.tournamentPanel,
      profilePanelShowing: state => state.panels.profilePanel,
      teamPanelShowing: state => state.panels.teamPanel,
      teamProfilePanelShowing: state => state.panels.teamProfilePanel
    })
  },

  methods: {
    closeModal() {
      this.loginDialog = false;
    },
    logout() {
      this.$store.dispatch("user/logout");
    }
  }
};
</script>

<style>
@font-face {
  font-family: "Fifa Font";
  src: url("static/fonts/fifafont-webfont.eot");
  src: url("static/fonts/fifafont-webfont.woff") format("woff"),
    url("static/fonts/fifafont-webfont.svg") format("svg"),
    url("static/fonts/fifafont-webfont.ttf") format("truetype");
}

#title {
  padding-top: 10px;
  font-size: 3rem !important;
  font-family: "Fifa Font" !important;
}

.v-data-table th {
  font-size: 24px !important;
  color: #252423 !important;
  padding: 25px 0px 25px 20px !important;
}

.v-data-table td {
  font-size: 18px !important;
  padding: 25px !important;
  cursor: pointer !important;
}

#inspire {
  background: none;
}

.logo-btn::before {
  color: transparent;
}

.logo-btn:hover {
  color: transparent;
}
</style>
