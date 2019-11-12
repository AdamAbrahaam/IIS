<template>
  <v-card>
    <v-card-text>
      <v-container>
        <div class="title d-flex mt-5">
          <v-icon class="mr-2">mdi-account-multiple</v-icon>
          {{ team.name }}
          <v-spacer></v-spacer>
        </div>

        <v-divider></v-divider>

        <v-row class="d-flex align-center ml-5">
          <v-col cols="3">Members:</v-col>
          <v-col cols="9">
            <div
              v-if="
                currentUser &&
                  teamMembers.find(t => t.userId === currentUser.userId)
              "
            >
              <v-chip
                class="mr-2"
                v-for="member in teamMembers"
                :key="member.userId"
                close
                color="black"
                close-icon="mdi-delete"
                label
                outlined
                @click:close="userDel = member"
              >
                {{ member.fullName }}
              </v-chip>
            </div>
            <div v-else>
              <v-chip
                class="mr-2"
                v-for="member in teamMembers"
                :key="member.userId"
                color="black"
                label
                outlined
              >
                {{ member.fullName }}
              </v-chip>
            </div>
          </v-col>
        </v-row>
        <v-row
          class="d-flex align-center ml-5"
          v-if="
            currentUser &&
              teamMembers.find(t => t.userId === currentUser.userId)
          "
        >
          <v-col cols="3">Add user:</v-col>
          <v-col cols="8">
            <v-autocomplete
              v-model="newUser"
              :ref="newUser"
              :items="users"
              item-text="fullName"
              item-value="userId"
              color="white"
              flat
              placeholder="ex. Stano Lobotka"
              :error-messages="errorMsg"
              @change="isInTeam()"
            >
              <template v-slot:append-outer>
                <v-icon
                  v-if="newUser && !errorMsg"
                  size="30px"
                  class="pl-2"
                  style="cursor: pointer"
                  @click="addMember()"
                  >mdi-account-plus</v-icon
                >
              </template>
            </v-autocomplete>
          </v-col>
        </v-row>
        <v-row class="d-flex align-center ml-5" v-if="userDel.fullName">
          <v-col cols="5" class="red--text"
            >Delete <strong>{{ userDel.fullName }}</strong
            >?</v-col
          >
          <v-col cols="7" class="d-flex">
            <v-btn
              small
              color="error"
              class="mr-2"
              @click="deleteMember(userDel.userId)"
              >DELETE</v-btn
            >
            <v-btn small outlined @click="userDel = {}">CANCEL</v-btn>
          </v-col>
        </v-row>

        <div class="title mt-10">
          <v-icon class="mr-2">mdi-chart-line</v-icon>
          Statistics
        </div>
        <v-divider></v-divider>
        <v-row class="d-flex align-center ml-5">
          <v-col cols="2">Points:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="teamProfileStats.points"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
          <v-col cols="2">Games:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="teamProfileStats.games"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
        </v-row>
        <v-row class="d-flex align-center ml-5">
          <v-col cols="2">Wins:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="teamProfileStats.wins"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
          <v-col cols="2">Loses:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="teamProfileStats.loses"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
        </v-row>
        <v-row class="d-flex align-center ml-5">
          <v-col cols="2">Draws:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="teamProfileStats.draws"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
          <v-col cols="2">Goals:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="teamProfileStats.goals"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="blue darken-1" text @click="close()">Close</v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
import { mapState } from "vuex";
export default {
  name: "TeamProfile",
  data() {
    return {
      newUser: null,
      errorMsg: "",
      userDel: {}
    };
  },
  created() {
    this.$store.dispatch("user/getAll");
  },
  computed: {
    ...mapState({
      team: state => state.teams.team,
      teamProfileStats: state => state.teams.teamStats,
      teamMembers: state => state.teams.members,
      users: state => state.user.users,
      currentUser: state => state.user.currentUser
    })
  },
  methods: {
    isInTeam() {
      if (this.teamMembers.length === 2) {
        this.errorMsg = "Max. two members allowed!";
      } else if (this.teamMembers.find(t => t.userId === this.newUser)) {
        this.errorMsg = "User is already a member!";
      } else {
        this.errorMsg = "";
      }
    },
    async addMember() {
      let team = await this.$store.dispatch("teams/addUser", {
        userId: this.newUser,
        teamName: this.team.name
      });

      if (!team.error) {
        this.newUser = null;
      } else {
        this.errorMsg = team.error;
      }
    },
    async deleteMember(id) {
      let team = await this.$store.dispatch("teams/removeUser", {
        userId: id,
        teamName: this.team.name
      });

      if (team.error) {
        this.errorMsg = team.error;
      } else {
        if (this.teamMembers.length === 1) {
          this.$store.commit("user/SET_AFTER_TEAM_DELETE", this.currentUser);
          this.$store.dispatch("panels/setPanel", {
            show: false,
            panel: "teamProfilePanel"
          });
        }
        this.userDel = {};
      }
    },
    close() {
      this.$store.dispatch("panels/setPanel", {
        show: false,
        panel: "teamProfilePanel"
      });
    }
  }
};
</script>

<style lang="scss" scoped></style>
