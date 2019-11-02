<template>
  <v-card>
    <v-card-text>
      <v-container>
        <div class="title d-flex">
          <v-icon class="mr-2">mdi-information-outline</v-icon>
          Information
          <v-spacer></v-spacer>
          <v-icon
            v-if="profile.userId === currentUser.userId && !isEditing"
            style="cursor: pointer"
            @click="isEditing = true"
            >mdi-square-edit-outline</v-icon
          >
          <v-btn
            v-else-if="profile.userId === currentUser.userId && isEditing"
            height="30px"
            class="black--text"
            color="success"
            @click="isEditing = false"
          >
            <span>SAVE!</span>
          </v-btn>
        </div>

        <v-divider></v-divider>

        <v-row v-if="!isEditing" class="d-flex align-center ml-5">
          <v-col cols="2">Name:</v-col>
          <v-col cols="10">
            <v-text-field
              ref="profile.fullName"
              v-model="profile.fullName"
              class="mb-n8"
              :value="profile.fullName"
              flat
              solo
              :readonly="true"
            ></v-text-field>
          </v-col>
        </v-row>
        <div v-else>
          <v-row class="d-flex align-center ml-5">
            <v-col cols="2">First name:</v-col>
            <v-col cols="10">
              <v-text-field
                ref="profile.firstName"
                v-model="profile.firstName"
                class="mb-n7"
                :value="profile.firstName"
                :outlined="true"
                :readonly="false"
              ></v-text-field>
            </v-col>
          </v-row>
          <v-divider></v-divider>
          <v-row class="d-flex align-center ml-5">
            <v-col cols="2">Last name:</v-col>
            <v-col cols="10">
              <v-text-field
                ref="profile.lastName"
                v-model="profile.lastName"
                class="mb-n7"
                :value="profile.lastName"
                :outlined="true"
                :readonly="false"
              ></v-text-field>
            </v-col>
          </v-row>
        </div>

        <v-divider></v-divider>

        <v-row class="d-flex align-center ml-5">
          <v-col cols="2">E-mail:</v-col>
          <v-col cols="10">
            <v-text-field
              ref="profile.email"
              v-model="profile.email"
              class="mb-n7"
              :value="profile.email"
              :outlined="isEditing"
              :flat="!isEditing"
              :solo="!isEditing"
              :readonly="!isEditing"
            ></v-text-field>
          </v-col>
        </v-row>

        <v-divider></v-divider>

        <v-row class="d-flex align-center ml-5">
          <v-col cols="2">Team:</v-col>
          <v-col cols="10">
            <v-text-field
              v-if="profile.team"
              ref="profile.team"
              v-model="profile.team"
              class="mb-n7"
              :value="profile.team"
              :outlined="isEditing"
              :flat="!isEditing"
              :solo="!isEditing"
              :readonly="!isEditing"
            ></v-text-field>
            <v-text-field
              v-else
              class="mb-n7"
              value="None"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
        </v-row>

        <div class="title mt-10">
          <v-icon class="mr-2">mdi-chart-line</v-icon>
          Statistics
        </div>
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
  name: "ProfilePanel",
  data() {
    return {
      isEditing: false
    };
  },
  computed: {
    ...mapState({
      profile: state => state.user.profile,
      currentUser: state => state.user.currentUser,
      userStats: state => state.user.userStats
    })
  },
  methods: {
    async createTournament() {
      this.tournamentInfo.organizer = this.currentUser.fullName;
      this.tournament = await this.$store.dispatch(
        "tournaments/createTournament",
        this.tournamentInfo
      );

      if (!this.tournament.error) {
        this.tournamentInfo = {};
        this.$store.dispatch("tournamentPanel/setPanel", false);
        this.$router.push({
          name: "tournament",
          params: { tournamentId: this.tournament.tournamentId }
        });
      }
    },
    close() {
      this.$store.dispatch("profilePanel/setPanel", {
        show: false,
        profileId: null
      });
      this.editing = false;
    }
  }
};
</script>

<style lang="scss" scoped></style>
