<template>
  <div>
    <div id="header">
      {{ tournament.name }}
      <v-btn
        v-if="currentUser.fullName == tournament.organizer.fullName"
        class="black--text"
        color="#fbff09"
      >
        <span>Edit details!</span>
      </v-btn>
      <v-btn
        v-else-if="currentUser.fullName"
        class="black--text"
        color="#fa5a66"
      >
        <span>Join tournament!</span>
      </v-btn>
    </div>

    <v-tabs
      v-model="tab"
      background-color="#54fffb"
      color="#252423"
      grow
      slider-color="#252423"
    >
      <v-tab v-for="item in items" :key="item.name">
        {{ item.name }}
      </v-tab>
    </v-tabs>

    <v-row justify="center">
      <v-col lg="9" class="pa-0">
        <v-tabs-items v-model="tab">
          <!--<v-tab-item v-for="item in items" :key="item.name">
            <component :is="item.component" />
          </v-tab-item> -->
          <v-tab-item>
            <TournamentDetails />
          </v-tab-item>
          <v-tab-item>
            <Brackets />
          </v-tab-item>
          <v-tab-item>
            <Matches />
          </v-tab-item>
        </v-tabs-items>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import TournamentDetails from "@/components/TournamentDetails.vue";
import Brackets from "@/components/Brackets.vue";
import Matches from "@/components/Matches.vue";
import { mapState } from "vuex";

export default {
  name: "Tournament",
  components: {
    TournamentDetails,
    Brackets,
    Matches
  },
  props: ["tournamentId"],
  data() {
    return {
      tab: null,
      loaded: false,
      items: [
        {
          name: "Details",
          component: "TournamentDetails"
        },
        {
          name: "Brackets",
          component: "Brackets"
        },
        {
          name: "Matches",
          component: "Matches"
        }
      ]
    };
  },
  created() {
    this.$store.dispatch("tournaments/getTournament", this.tournamentId);
    this.loaded = true;
  },
  computed: {
    ...mapState({
      tournament: state => state.tournaments.tournament,
      currentUser: state => state.user.currentUser
    })
  }
};
</script>

<style lang="scss" scoped>
#header {
  background: url("../static/header.png") center;
  background-size: cover;
  height: 30vh;

  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

  color: #3bf8f7;
  font-size: 4rem;
  font-weight: bold;
  font-family: "Fifa Font", sans-serif;
  letter-spacing: 0.05em;

  .v-btn {
    font-family: Arial, Helvetica, sans-serif;
    font-weight: bold;
  }
}
</style>
