<template>
  <div>
    <DefaultHeader>
      <div slot="title">Player Rankings</div>

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
              :headers="playerHeaders"
              :items="statsWithRank"
              :sort-desc="[false, true]"
              multi-sort
              :mobile-breakpoint="800"
              hide-default-footer
              class="elevation-12"
              @click:row="showProfile($event.userUserId)"
            >
              <template v-slot:item.no="{ item }">
                <strong>{{ item.no }}</strong>
              </template>
              <template v-slot:item.player="{ item }">
                {{ item.userFullName }}
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
      playerHeaders: [
        { text: "#", value: "no" },
        { text: "Player", value: "player" },
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
  },
  computed: {
    ...mapState({
      playerStats: state => state.statistics.playerStats
    }),
    statsWithRank() {
      let rank = 1;
      this.playerStats.forEach(element => {
        element.no = rank++;
      });
      return this.playerStats;
    }
  },
  methods: {
    showProfile(id) {
      this.$store.dispatch("panels/setPanel", {
        show: true,
        panel: "profilePanel",
        profileId: id
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
