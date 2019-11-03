<template>
  <v-card>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              ref="teamInfo.name"
              v-model="teamInfo.name"
              label="Name"
              type="text"
              required
              prepend-icon="mdi-format-letter-case"
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-img
              v-if="url"
              :src="url"
              max-height="300px"
              max-width="300px"
            ></v-img>
            <input type="file" accept="image/*" @change="onFileChanged" />
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="blue darken-1" text @click="close()">Close</v-btn>
      <v-btn v-if="isEditing" color="blue darken-1" text @click="update()"
        >Save</v-btn
      >
      <v-btn v-else color="blue darken-1" text @click="createTeam()"
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
        logo: "",
        userId: ""
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
      this.tournamentInfo.organizer = this.currentUser.fullName;
      /*this.tournament = await this.$store.dispatch(
        "tournaments/createTournament",
        this.tournamentInfo
      );*/

      if (!this.tournament.error) {
        this.tournamentInfo = {};
        this.$store.dispatch("panels/setPanel", {
          show: false,
          panel: "tournamentPanel",
          profileId: null
        });
        this.$router.push({
          name: "tournament",
          params: { tournamentId: this.tournament.tournamentId }
        });
      }
    },
    close() {
      this.$store.dispatch("panels/setPanel", {
        show: false,
        panel: "teamPanel",
        profileId: null
      });
      this.$store.dispatch("tournaments/setEditing", false);
    }
  }
};
</script>

<style lang="scss" scoped></style>
