<template>
  <div>
    <DefaultHeader>
      <div slot="title">Tournaments</div>
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
          :items="tournaments"
          :sort-desc="[false, true]"
          multi-sort
          :mobile-breakpoint="800"
          hide-default-footer
          class="elevation-12"
          @click:row="
            $router.push({
              name: 'tournament',
              params: { tournamentId: $event.tournamentId }
            })
          "
        >
          <template v-slot:item.type="{ item }">
            <v-icon>{{
              item.type == "Duo" ? "mdi-account-multiple" : "mdi-account"
            }}</v-icon>
          </template>
          <template v-slot:item.entry="{ item }">
            {{ item.entry }}€
          </template>
          <template v-slot:item.prize="{ item }">
            {{ item.prize }}€
          </template></v-data-table
        ></v-card
      >
    </DefaultHeader>
  </div>
</template>

<script>
import { mapState } from "vuex";
import DefaultHeader from "@/views/DefaultHeader.vue";
export default {
  name: "Tournaments",
  components: {
    DefaultHeader
  },
  data() {
    return {
      search: "",
      headers: [
        { text: "Name", value: "name" },
        { text: "Date", value: "date" },
        { text: "Time", value: "time" },
        { text: "Location", value: "location" },
        { text: "Type", value: "type" },
        { text: "Entry", value: "entry" },
        { text: "Prize", value: "prize" }
      ]
    };
  },
  created() {
    this.$store.dispatch("tournaments/getAll");
  },
  computed: {
    ...mapState({
      tournaments: state => state.tournaments.tournaments,
      currentUser: state => state.user.currentUser
    })
  }
};
</script>

<style lang="scss" scoped>
#table {
  max-width: 1440px;
  width: 100%;
}
</style>
