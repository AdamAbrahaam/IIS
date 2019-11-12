<template>
  <v-card>
    <v-card-text>
      <v-container>
        <div v-if="currentUser.team">
          <div class="title d-flex justify-center mt-5">
            You already have a team!
          </div>
        </div>
        <div v-else>
          <div class="title d-flex mt-5">
            <v-icon class="mr-2">mdi-plus-box</v-icon>
            Create your team!
          </div>
          <v-divider></v-divider>
          <v-row class="d-flex align-center ml-5 mt-5">
            <v-col cols="3">*Team name:</v-col>
            <v-col cols="8">
              <v-text-field
                ref="teamInfo.name"
                v-model="teamInfo.name"
                class="mb-n7"
                placeholder="ex. Cisco Raptors"
                :outlined="true"
                :readonly="false"
              ></v-text-field>
            </v-col>
          </v-row>
          <v-row class="d-flex align-center ml-5">
            <v-col cols="12">*Choose a logo from below:</v-col>
          </v-row>
          <v-row class="d-flex align-center ml-5">
            <v-col cols="12" class="d-flex justify-space-between">
              <v-avatar
                id="logo1"
                class="logo"
                size="80"
                @click="setLogo('logo1')"
              >
                <img src="../static/teamlogos/1.png" />
              </v-avatar>
              <v-avatar
                id="logo2"
                class="logo"
                size="80"
                @click="setLogo('logo2')"
              >
                <img src="../static/teamlogos/2.png" />
              </v-avatar>
              <v-avatar
                id="logo3"
                class="logo"
                size="80"
                @click="setLogo('logo3')"
              >
                <img src="../static/teamlogos/3.png" />
              </v-avatar>
              <v-avatar
                id="logo4"
                class="logo"
                size="80"
                @click="setLogo('logo4')"
              >
                <img src="../static/teamlogos/4.png" />
              </v-avatar>
            </v-col>
          </v-row>
          <v-row
            v-if="errorMsg"
            class="d-flex align-center justify-center ml-5 red--text mt-5"
          >
            {{ errorMsg }}
          </v-row>
        </div>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="blue darken-1" text @click="close()">Close</v-btn>
      <v-btn
        v-if="!currentUser.team"
        color="blue darken-1"
        text
        @click="createTeam()"
        >Create team</v-btn
      >
    </v-card-actions>
  </v-card>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "TeamPanel",
  props: ["closeModal", "editInfo", "isEditing"],
  data() {
    return {
      currentLogo: undefined,
      errorMsg: "",
      teamInfo: {
        name: "",
        logo: 0
      }
    };
  },
  computed: {
    ...mapState({
      currentUser: state => state.user.currentUser
    })
  },
  methods: {
    setLogo(logo) {
      if (this.currentLogo) {
        let current = document.getElementById(this.currentLogo);
        current.style.opacity = 0.3;
      }

      let selected = document.getElementById(logo);
      selected.style.opacity = 1;

      this.currentLogo = logo;
    },
    async createTeam() {
      if (!this.currentLogo) {
        this.errorMsg = "All fields are requiered!";
        setTimeout(() => {
          this.errorMsg = "";
        }, 3000);
        return;
      }

      this.teamInfo.logo = this.currentLogo[this.currentLogo.length - 1];
      console.log(this.teamInfo);
      let team = await this.$store.dispatch("teams/createTeam", {
        teamInfo: this.teamInfo,
        userId: this.currentUser.userId
      });

      if (!team.error) {
        this.currentUser.team = team;
        this.teamInfo = {};
        this.$store.dispatch("panels/setPanel", {
          show: false,
          panel: "teamPanel",
          profileId: null
        });
        this.$store.dispatch("panels/setPanel", {
          show: true,
          panel: "teamProfilePanel",
          teamName: this.currentUser.team.name
        });
      }
    },
    close() {
      this.$store.dispatch("panels/setPanel", {
        show: false,
        panel: "teamPanel",
        profileId: null
      });
    }
  }
};
</script>

<style lang="scss" scoped>
.logo {
  opacity: 0.3;
}
</style>
