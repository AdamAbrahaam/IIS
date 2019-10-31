<template>
  <div>
    <DefaultHeader>
      <div slot="title">Rankings</div>
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

      <v-card
        height="100px"
        color="#54fffb"
        class="d-flex align-center justify-center"
        ><v-card max-width="1440px" width="100%">
          <v-text-field
            class="elevation-3"
            v-model="$refs.rankingTable.search"
            append-icon="mdi-magnify"
            full-width
            label="Search"
            single-line
            hide-details
          ></v-text-field>
        </v-card>
      </v-card>

      <v-row justify="center">
        <v-col class="pa-0">
          <v-tabs-items v-model="tab">
            <v-tab-item>
              <RankingTable
                :headers="playerHeaders"
                :stats="playerStats"
                ref="rankingTable"
              />
            </v-tab-item>
            <v-tab-item>
              <RankingTable
                :headers="teamHeaders"
                :stats="teamStats"
                ref="rankingTable"
              />
            </v-tab-item>
          </v-tabs-items>
        </v-col>
      </v-row>
    </DefaultHeader>
  </div>
</template>

<script>
import { mapState } from "vuex";
import DefaultHeader from "@/views/DefaultHeader.vue";
import RankingTable from "@/components/RankingTable.vue";

export default {
  name: "Ranking",
  components: {
    DefaultHeader,
    RankingTable
  },
  data() {
    return {
      tab: null,
      items: [
        {
          name: "Players",
          component: "PlayerRankings"
        },
        {
          name: "Teams",
          component: "TeamRankings"
        }
      ],
      search: "",
      playerHeaders: [
        { text: "#", value: "no" },
        { text: "Player", value: "player" },
        { text: "Points", value: "points" },
        { text: "Games", value: "games" },
        { text: "Wins", value: "wins" },
        { text: "Loses", value: "loses" },
        { text: "Draws", value: "draws" },
        { text: "Goals", value: "goals" }
      ],
      teamHeaders: [
        { text: "#", value: "no" },
        { text: "Team", value: "team" },
        { text: "Points", value: "points" },
        { text: "Games", value: "games" },
        { text: "Wins", value: "wins" },
        { text: "Loses", value: "loses" },
        { text: "Draws", value: "draws" },
        { text: "Goals", value: "goals" }
      ]
    };
  },
  created() {
    this.$store.dispatch("statistics/getAllUserStats");
    this.$store.dispatch("statistics/getAllTeamStats");
  },
  computed: {
    ...mapState({
      playerStats: state => state.statistics.playerStats,
      teamStats: state => state.statistics.teamStats
    })
  }
};
</script>

<style scoped></style>
