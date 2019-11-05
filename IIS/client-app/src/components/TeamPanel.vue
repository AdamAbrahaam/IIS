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
            <v-col cols="3">*Team logo:</v-col>
            <v-col cols="9">
              <input
                type="file"
                accept="image/jpeg, image/png"
                @change="onFileChanged"
                ref="file"
                style="display: none"
              />

              <v-btn outlined color="#c2c2c2" @click="$refs.file.click()"
                >Browse Images...</v-btn
              >
              <input />
            </v-col>
          </v-row>
          <v-row class="d-flex align-center justify-center mt-5">
            <v-avatar size="150" v-if="url"
              ><v-img :src="url" max-height="300px" max-width="300px"></v-img
            ></v-avatar>
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
      teamInfo: {
        name: "",
        logo: ""
      },
      url: null
    };
  },
  computed: {
    ...mapState({
      currentUser: state => state.user.currentUser
    })
  },
  methods: {
    onFileChanged(event) {
      this.teamInfo.logo = event.target.files[0];
      this.url = URL.createObjectURL(this.teamInfo.logo);
    },
    async createTeam() {
      this.teamInfo.logo = null;
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

<style lang="scss" scoped></style>
