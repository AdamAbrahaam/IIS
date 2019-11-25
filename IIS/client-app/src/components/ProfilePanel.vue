<template>
  <v-card>
    <v-card-text>
      <v-container>
        <div class="title d-flex mt-5">
          <v-icon class="mr-2">mdi-information-outline</v-icon>
          Information
          <v-spacer></v-spacer>
          <v-icon
            v-if="
              (profile.userId === currentUser.userId && !isEditing) ||
                (currentUser.isAdmin && !isEditing)
            "
            style="cursor: pointer"
            @click="isEditing = true"
            >mdi-square-edit-outline</v-icon
          >
          <div
            v-else-if="
              (profile.userId === currentUser.userId && isEditing) ||
                (currentUser.isAdmin && isEditing)
            "
            class="mb-2"
          >
            <v-btn
              height="30px"
              outlined
              class="black--text mr-2"
              @click="isEditing = false"
            >
              <span>CANCEL!</span>
            </v-btn>
            <v-btn
              height="30px"
              class="black--text"
              color="success"
              @click="update()"
            >
              <span>SAVE!</span>
            </v-btn>
          </div>
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

        <v-row class="d-flex align-center ml-5">
          <v-col cols="2">Team:</v-col>
          <v-col cols="10">
            <v-text-field
              v-if="profile.team"
              ref="profile.team.name"
              v-model="profile.team.name"
              class="mb-n7"
              :value="profile.team.name"
              solo
              flat
              :readonly="true"
              :error-messages="errorMsg"
            ></v-text-field>
            <v-text-field
              v-else
              class="mb-n7"
              value="None"
              solo
              flat
              :readonly="true"
              :error-messages="errorMsg"
            ></v-text-field>
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
              :value="userStats.points"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
          <v-col cols="2">Games:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="userStats.games"
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
              :value="userStats.wins"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
          <v-col cols="2">Loses:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="userStats.loses"
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
              :value="userStats.draws"
              solo
              flat
              :readonly="true"
            ></v-text-field>
          </v-col>
          <v-col cols="2">Goals:</v-col>
          <v-col cols="4">
            <v-text-field
              class="mb-n7"
              :value="userStats.goals"
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
  name: "ProfilePanel",
  data() {
    return {
      isEditing: false,
      errorMsg: ""
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
    async update() {
      let updatedInfo = this.profile;
      let response = await this.$store.dispatch("user/updateProfile", {
        profileId: updatedInfo.userId,
        updatedInfo: updatedInfo
      });

      if (!response.error) {
        this.isEditing = false;
      } else {
        this.errorMsg = response.error;
        setTimeout(() => {
          this.errorMsg = "";
        }, 3000);
      }
    },
    close() {
      this.$store.dispatch("panels/setPanel", {
        show: false,
        panel: "profilePanel",
        profileId: null
      });
      this.editing = false;
    }
  }
};
</script>

<style lang="scss" scoped></style>
