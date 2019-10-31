<template>
  <div>
    <div id="header">
      {{ tournament.name }}
      <v-btn
        v-if="currentUser.fullName == tournament.organizer && !editingState"
        class="black--text"
        color="#fbff09"
        @click="edit()"
      >
        <span>Edit details!</span>
      </v-btn>
      <div
        v-else-if="currentUser.fullName == tournament.organizer && editingState"
        class="d-flex flex-column"
      >
        <v-btn
          class="black--text mb-3"
          color="error"
          @click="deleteModal = true"
        >
          <span>Delete tournament!</span>
        </v-btn>
        <v-btn
          class="black--text"
          color="success"
          @click="$refs.tournamentDetails.update()"
        >
          <span>SAVE!</span>
        </v-btn>
      </div>

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
          <v-tab-item>
            <TournamentDetails ref="tournamentDetails" />
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

    <v-dialog
      v-model="deleteModal"
      persistent
      overlay-opacity="0.8"
      max-width="300px"
    >
      <v-card>
        <v-card-text class="pt-5">
          <v-container class="headline">Are you sure?</v-container>
        </v-card-text>
        <v-card-actions>
          <div class="flex-grow-1"></div>
          <v-btn color="blue darken-1" text @click.prevent="deleteModal = false"
            >CANCEL</v-btn
          >
          <v-btn color="error black--text" @click.prevent="deleteTournament()"
            >DELETE</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-dialog>
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
      deleteModal: false,
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
    this.$store.dispatch("tournaments/setEditing", false);
    this.loaded = true;
  },
  computed: {
    ...mapState({
      tournament: state => state.tournaments.tournament,
      currentUser: state => state.user.currentUser,
      editingState: state => state.tournaments.editing
    })
  },
  methods: {
    edit() {
      this.$store.dispatch("tournaments/setEditing", true);
      this.$refs.tournamentDetails.deleteEur();
    },
    deleteTournament() {
      this.$store.dispatch("tournaments/setEditing", false);
      this.$store.dispatch(
        "tournaments/deleteTournament",
        this.tournament.tournamentId
      );
      this.$router.push({
        name: "tournaments"
      });
    }
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
