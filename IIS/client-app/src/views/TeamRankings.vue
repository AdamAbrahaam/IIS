<template>
  <div>
    <DefaultHeader>
      <div slot="title">Team Rankings</div>

      <v-row justify="center">
        <v-col class="pa-0">
          <v-card
            height="100px"
            color="#54fffb"
            class="d-flex align-center justify-center"
            ><v-card max-width="1440px" width="100%">
              <v-text-field
                class="elevation-3"
                v-model="search"
                append-icon="mdi-magnify"
                full-width
                label="Search"
                single-line
                hide-details
              ></v-text-field>
            </v-card>
          </v-card>

          <v-card flat class="d-flex align-center justify-center my-7">
            <v-data-table
              id="table"
              :search="search"
              :headers="teamHeaders"
              :items="statsWithRank"
              :sort-desc="[false, true]"
              multi-sort
              :mobile-breakpoint="800"
              hide-default-footer
              class="elevation-12"
              @click:row="showProfile($event.team)"
            >
              <template v-slot:item.no="{ item }">
                <strong>{{ item.no }}</strong>
              </template>
              <template v-slot:item.player="{ item }">
                {{ item.team }}
              </template>
            </v-data-table></v-card
          >
        </v-col>
      </v-row>
    </DefaultHeader>
  </div>
</template>

<script>
import { mapState } from "vuex";
import DefaultHeader from "@/views/DefaultHeader.vue";

export default {
  name: "Ranking",
  components: {
    DefaultHeader
  },
  data() {
    return {
      tab: null,
      search: "",
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
    this.$store.dispatch("statistics/getAllTeamStats");
  },
  computed: {
    ...mapState({
      teamStats: state => state.statistics.teamStats
    }),
    statsWithRank() {
      let rank = 1;
      this.teamStats.forEach(element => {
        element.no = rank++;
      });
      return this.teamStats;
    }
  },
  methods: {
    showProfile(name) {
      this.$store.dispatch("panels/setPanel", {
        show: true,
        panel: "teamProfilePanel",
        teamName: name
      });
    }
  }
};
</script>

<style scoped>
#table {
  max-width: 1440px;
  width: 100%;
}
</style>
