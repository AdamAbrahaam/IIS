<template>
  <v-card>
    <v-card-text>
      <v-container>
        <div class="title d-flex mt-5">
          <v-icon class="mr-2">mdi-information-outline</v-icon>
          {{ team.name }}
          <v-spacer></v-spacer>
        </div>

        <v-divider></v-divider>

        <v-row class="d-flex align-center ml-5">
          <v-col cols="3">Members:</v-col>
          <v-col cols="9">
            <v-chip
              class="mr-2"
              v-for="member in teamMembers"
              :key="member.userId"
              close
              color="black"
              close-icon="mdi-delete"
              label
              outlined
              @click:close="deleteMember(member.userId)"
            >
              {{ member.fullName }}
            </v-chip>
          </v-col>
        </v-row>
        <v-row class="d-flex align-center ml-5">
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
              placeholder="Stano Lobotka"
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
      errorMsg: ""
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
      users: state => state.user.users
    })
  },
  methods: {
    isInTeam() {
      if (this.teamMembers.find(t => t.userId === this.newUser)) {
        this.errorMsg = "User is already a member!";
      } else {
        this.errorMsg = "";
      }
    },
    addMember() {},
    deleteMember() {},
    close() {
      this.$store.dispatch("panels/setPanel", {
        show: false,
        panel: "teamProfilePanel"
      });
      this.editing = false;
    }
  }
};
</script>

<style lang="scss" scoped></style>
