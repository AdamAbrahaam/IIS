<template>
  <div>
    <div id="header">
      <v-col class="text-center white--text" cols="12">
        {{ tournament.name }}
      </v-col>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "Tournament",
  props: ["tournamentId"],
  data() {
    return {};
  },
  created() {
    this.$store.dispatch("tournaments/getTournament", this.tournamentId);
  },
  computed: {
    ...mapState({
      tournament: state => state.tournaments.tournament
    })
  }
};
</script>

<style lang="scss" scoped>
#header {
  background: url("../static/header.png") center;
  background-size: cover;
  height: 15vw;

  display: flex;
  align-items: center;

  color: white;
  font-size: 4rem;
  font-weight: bold;
  font-family: "Fifa Font", sans-serif;
  letter-spacing: 0.05em;
}
</style>
