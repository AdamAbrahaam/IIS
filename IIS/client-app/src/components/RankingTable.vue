<template>
  <div>
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
        :headers="headers"
        :items="statsWithRank"
        :sort-desc="[false, true]"
        multi-sort
        :mobile-breakpoint="800"
        hide-default-footer
        class="elevation-12"
      >
        <template v-slot:item.no="{ item }">
          <strong>{{ item.no }}</strong>
        </template>
        <template v-slot:item.player="{ item }">
          <div v-if="item.userFullName">
            {{ item.userFullName }}
          </div>
          <div v-else-if="item.team">{{ item.team }}</div>
        </template>
      </v-data-table></v-card
    >
  </div>
</template>

<script>
export default {
  name: "RankingTable",
  props: ["headers", "stats"],
  data: () => {
    return {
      search: ""
    };
  },
  computed: {
    statsWithRank() {
      let rank = 1;
      this.stats.forEach(element => {
        element.no = rank++;
      });
      return this.stats;
    }
  }
};
</script>

<style lang="scss" scoped>
#table {
  max-width: 1440px;
  width: 100%;
}
</style>
