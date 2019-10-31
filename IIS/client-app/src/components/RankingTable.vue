<template>
  <div>
    <v-card flat class="d-flex align-center justify-center my-7">
      <v-data-table
        id="table"
        :search="search"
        :headers="headers"
        :items="stats"
        :sort-desc="[false, true]"
        multi-sort
        :mobile-breakpoint="800"
        hide-default-footer
        class="elevation-12"
      >
        <template v-slot:item.no="{ item }">
          <strong>{{
            stats
              .map(function(x) {
                return x.id;
              })
              .indexOf(item.id) + 1
          }}</strong>
        </template>
        <template v-slot:item.player="{ item }">
          <div v-if="item.user">{{ item.user.fullName }}</div>
          <div v-else-if="item.team">{{ item.team.name }}</div>
        </template>
      </v-data-table></v-card
    >
  </div>
</template>

<script>
export default {
  name: "RankingTable",
  props: ["headers", "stats"],
  data() {
    return {
      search: ""
    };
  }
};
</script>

<style lang="scss" scoped>
#table {
  max-width: 1440px;
  width: 100%;
}
</style>
