<template>
  <div>
    <v-card
      v-if="tournament.organizer == currentUser.fullName"
      height="80px"
      class="mx-3 my-7 py-4 px-12 mx-sm-12 elevation-5 d-flex justify-space-between"
    >
      <v-card flat>
        <v-autocomplete
          v-model="home"
          :ref="home"
          :items="tournament.participants"
          item-text="name"
          item-value="userOrTeam"
          color="white"
          solo
          placeholder="Home"
        >
        </v-autocomplete>
      </v-card>

      <v-btn fab dark color="indigo" class="mx-5" @click="addMatch()">
        <v-icon size="30" dark>mdi-plus</v-icon>
      </v-btn>

      <v-card flat>
        <v-autocomplete
          v-model="away"
          :ref="away"
          :items="tournament.participants"
          color="white"
          item-text="name"
          item-value="userOrTeam"
          solo
          placeholder="Away"
        >
        </v-autocomplete>
      </v-card>
    </v-card>
    <v-divider></v-divider>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "Matches",
  data() {
    return {
      home: "",
      away: ""
    };
  },
  computed: {
    ...mapState({
      tournament: state => state.tournaments.tournament,
      currentUser: state => state.user.currentUser,
      matches: state => state.matches.matches
    })
  },
  methods: {
    addMatch() {
      let match = {};
      let type = this.tournament.type;

      if (type == "Solo") {
        match.Home = this.home;
        match.Away = this.away;
      } else if (type == "Duo") {
        match.HomeTeam = this.tournament.participants.find(
          t => t.userOrTeam == this.home
        ).name;
        match.AwayTeam = this.tournament.participants.find(
          t => t.userOrTeam == this.away
        ).name;
      }

      match.TournamentId = this.tournament.tournamentId;
      this.$store.dispatch("matches/addMatch", match);
    }
  }
};
</script>

<style scoped></style>
