<template>
  <div>
    <div
      v-if="tournament.referee == currentUser.fullName"
      class="mx-xs-12 mt-8"
    >
      <v-card class="elevation-12">
        <v-card class="display-1 pa-3 white--text" color="indigo">
          Referee panel
        </v-card>
        <div class="d-flex flex-column align-center mt-3">
          <div class="mx-sm-12 d-flex justify-space-between align-center">
            <v-select
              class="mr-4 mt-7"
              v-model="home"
              :ref="home"
              :items="tournament.participants"
              item-text="name"
              item-value="userOrTeam"
              color="white"
              solo
              placeholder="Home"
            >
            </v-select>

            <div class="title mr-4">
              VS
            </div>

            <v-select
              class="mr-4 mt-7"
              v-model="away"
              :ref="away"
              :items="tournament.participants"
              color="white"
              item-text="name"
              item-value="userOrTeam"
              solo
              placeholder="Away"
            >
            </v-select>

            <div class="title mr-4 ml-12">Round:</div>
            <v-select
              class=" mt-7"
              v-model="round"
              :ref="round"
              :items="rounds"
              color="white"
              solo
              placeholder="Round"
            >
            </v-select>
          </div>

          <v-btn
            :loading="loading"
            :disabled="loading"
            width="50%"
            class="mb-5"
            dark
            color="indigo"
            @click="addMatch()"
          >
            ADD MATCH!
          </v-btn>

          <v-switch
            v-model="scoreEditing"
            :label="scoreEditing ? 'Score editing ON!' : 'Score editing OFF!'"
            color="green"
          ></v-switch>
          <div v-if="scoreEditing" class="mb-3 mt-n3 green--text">
            Click on a match to add score!
          </div>
        </div>
      </v-card>
    </div>

    <v-divider class="mb-7"></v-divider>

    <div v-if="!matches.length" class="text-center grey--text">
      The referee did not add a match yet.
    </div>

    <div v-for="round in matchRounds" :key="round.id">
      <div v-if="round.length" class="mt-8">
        <div class="display-1 ml-12 mb-2">Round {{ round[0].round }}</div>
        <v-card
          v-for="match in round"
          :key="match.matchId"
          class="elevation-5 mx-3 mb-3 mx-sm-12 d-flex justify-center align-center"
          @click.prevent="scoreEditing ? showScorePanel(match) : ''"
        >
          <div
            class="player pa-5"
            v-bind:class="[{ winner: match.winner == 'Home' }]"
          >
            <v-card flat class="title" color="transparent">
              {{ match.home ? match.home.fullName : match.homeTeam }}
            </v-card>
          </div>

          <div
            @click="
              !scoreEditing
                ? match.home
                  ? participantProfile(match.home.userId, true)
                  : participantProfile(match.homeTeam, false)
                : ''
            "
            class="vs display-1 indigo--text pa-5"
            style="cursor: pointer"
          >
            <div v-if="match.winner">
              {{ match.homeScore }} : {{ match.awayScore }}
            </div>
            <div v-else>VS</div>
          </div>

          <div
            @click="
              !scoreEditing
                ? match.away
                  ? participantProfile(match.away.userId, true)
                  : participantProfile(match.awayTeam, false)
                : ''
            "
            class="player pa-5"
            v-bind:class="[{ winner: match.winner == 'Away' }]"
          >
            <v-card flat color="transparent" class="title text-right">
              {{ match.away ? match.away.fullName : match.awayTeam }}
            </v-card>
          </div>
        </v-card>
        <v-divider class="mt-12"></v-divider>
      </div>
    </div>

    <v-dialog
      v-model="scoreShowing"
      persistent
      overlay-opacity="0.8"
      max-width="600px"
    >
      <v-card>
        <v-card-text>
          <v-container class="pt-12">
            <div class="d-flex title">
              Home score:
              <v-slider
                class="pl-3"
                v-model="homeScore"
                thumb-label="always"
                max="30"
              ></v-slider>
            </div>
            <div class="d-flex pt-5 title">
              Away score:
              <v-slider
                class="pl-3"
                v-model="awayScore"
                thumb-label="always"
                max="30"
              ></v-slider>
            </div>
            <div class="d-flex justify-center align-center display-1">
              {{ homeScore }} : {{ awayScore }}
            </div>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <div class="flex-grow-1"></div>
          <v-btn color="blue darken-1" text @click="scoreShowing = false"
            >Close</v-btn
          >
          <v-btn color="blue darken-1" text @click="addScore()"
            >Add score!</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import { mapState, mapGetters } from "vuex";
export default {
  name: "Matches",
  data() {
    return {
      loading: false,
      homeScore: 0,
      awayScore: 0,
      scoreShowing: false,
      scoreEditing: false,
      currentMatch: {},
      home: "",
      away: "",
      round: 1,
      rounds: [1, 2, 3, 4]
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
    }),
    ...mapGetters({
      matchRounds: "matches/setRounds"
    })
  },
  methods: {
    async addScore() {
      this.currentMatch.homeScore = this.homeScore;
      this.currentMatch.awayScore = this.awayScore;

      if (this.currentMatch.homeScore > this.currentMatch.awayScore) {
        this.currentMatch.winner = "Home";
      } else if (this.currentMatch.homeScore < this.currentMatch.awayScore) {
        this.currentMatch.winner = "Away";
      } else if (this.currentMatch.homeScore == this.currentMatch.awayScore) {
        this.currentMatch.winner = "Draw";
      }

      await this.$store.dispatch("matches/addScore", this.currentMatch);
      this.scoreShowing = false;
    },
    showScorePanel(match) {
      if (match.winner) {
        this.homeScore = match.homeScore;
        this.awayScore = match.awayScore;
      } else {
        this.homeScore = 0;
        this.awayScore = 0;
      }
      this.scoreShowing = true;
      this.currentMatch = match;
    },
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
      this.loading = true;
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
      match.Round = this.round;
      this.$store.dispatch("matches/addMatch", match);
      this.loading = false;
    }
  }
};
</script>

<style scoped>
.player {
  width: 100%;
  height: 100%;
  cursor: pointer;
}

.winner {
  background: #57e157;
}

.loser {
  background: red;
}

.vs {
  position: absolute;
  text-align: center;
  height: 100%;
  width: 100%;
  background: rgb(255, 255, 255);
  background: radial-gradient(
    circle,
    rgba(255, 255, 255, 1) 10%,
    rgba(0, 212, 255, 0) 80%
  );
}
</style>
