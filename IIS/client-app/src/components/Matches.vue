<template>
  <div style="background-color: #e7e6e3;">
    <v-card
      v-if="tournament.organizer == currentUser.fullName"
      height="80px"
      class="mx-3 my-7 py-4 px-12 mx-sm-12 elevation-2 d-flex justify-space-between"
    >
      <v-card>
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

    <v-divider class="mb-7"></v-divider>

    <v-card
      v-for="match in matches"
      :key="match.matchId"
      height="80px"
      class="elevation-2 mx-3 mb-3 px-12 mx-sm-12 d-flex justify-space-between align-center"
    >
      <v-card
        flat
        min-width="300px"
        class="title"
        @click="
          match.home
            ? participantProfile(match.home.userId, true)
            : participantProfile(homeTeam, false)
        "
      >
        {{ match.home ? match.home.fullName : match.homeTeam }}
      </v-card>

      <div class="display-1 indigo--text">
        VS
      </div>

      <v-card
        flat
        min-width="300px"
        class="title text-right"
        @click="
          match.away
            ? participantProfile(match.away.userId, true)
            : participantProfile(awayTeam, false)
        "
      >
        {{ match.away ? match.away.fullName : match.awayTeam }}
      </v-card>
    </v-card>
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
  created() {
    this.$store.dispatch("matches/getMatches", this.tournament.tournamentId);
  },
  computed: {
    ...mapState({
      tournament: state => state.tournaments.tournament,
      currentUser: state => state.user.currentUser,
      matches: state => state.matches.matches
    })
  },
  methods: {
    participantProfile(id, isUser) {
      if (isUser) {
        this.$store.dispatch("panels/setPanel", {
          show: true,
          panel: "profilePanel",
          profileId: id
        });
      } else {
        this.$store.dispatch("panels/setPanel", {
          show: true,
          panel: "teamProfilePanel",
          teamName: id
        });
      }
    },
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
      match.Round = 1;
      this.$store.dispatch("matches/addMatch", match);
    }
  }
};
</script>

<style scoped></style>
