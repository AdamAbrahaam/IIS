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
        <v-btn class="black--text" color="error" @click="deleteModal = true">
          <span>Delete tournament!</span>
        </v-btn>
        <div class="mt-n5">
          <v-btn
            width="100px"
            class="black--text"
            color="success"
            @click="$refs.tournamentDetails.update()"
          >
            <span>SAVE!</span>
          </v-btn>
          <v-btn
            width="100px"
            class="black--text ml-3"
            color="#3bf8f7"
            @click="cancel()"
          >
            <span>CANCEL!</span>
          </v-btn>
        </div>
      </div>

      <v-btn
        v-else-if="
          currentUser.fullName && currentUser.fullName != tournament.referee
        "
        class="black--text"
        color="#fa5a66"
        @click.prevent="joinTournament()"
      >
        <span>Join tournament!</span>
      </v-btn>
      <span class="title"> {{ errorMsg }}</span>
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
          <v-tab-item
            transition="fade-transition"
            reverse-transition="fade-transition"
          >
            <TournamentDetails ref="tournamentDetails" /> </v-tab-item
          ><v-tab-item
            transition="fade-transition"
            reverse-transition="fade-transition"
          >
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
import Matches from "@/components/Matches.vue";
import { mapState } from "vuex";

export default {
  name: "Tournament",
  components: {
    TournamentDetails,
    Matches
  },
  props: ["tournamentId"],
  data() {
    return {
      tab: null,
      loaded: false,
      deleteModal: false,
      errorMsg: "",
      items: [
        {
          name: "Details",
          component: "TournamentDetails"
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
      editingState: state => state.tournaments.editing,
      matches: state => state.matches.matches
    })
  },
  methods: {
    joinTournament() {
      let type = this.$refs.tournamentDetails.tournament.type;
      let response;
      if (type === "Solo") {
        if (
          this.tournament.participants.find(
            t => t.userOrTeam === this.currentUser.userId
          )
        ) {
          this.errorMsg = "You already joined!";
          setTimeout(() => {
            this.errorMsg = "";
          }, 3000);
        } else {
          response = this.$store.dispatch("tournaments/addPlayer", {
            userId: this.currentUser.userId,
            tournamentId: this.tournament.tournamentId
          });
        }
      } else if (type === "Duo") {
        if (this.currentUser.team) {
          if (
            this.tournament.participants.find(
              t => t.userOrTeam === this.currentUser.team.teamId
            )
          ) {
            this.errorMsg = "You already joined!";
            setTimeout(() => {
              this.errorMsg = "";
            }, 3000);
          } else {
            response = this.$store.dispatch("tournaments/addTeam", {
              teamId: this.currentUser.team.teamid,
              tournamentId: this.tournament.tournamentId
            });
          }
        } else {
          this.$store.dispatch("panels/setPanel", {
            show: true,
            panel: "teamPanel",
            profileId: null
          });
        }
      }
      console.log(response);
    },
    edit() {
      this.$store.dispatch("tournaments/setEditing", true);
      this.$refs.tournamentDetails.deleteEur();
    },
    cancel() {
      this.$store.dispatch("tournaments/setEditing", false);
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
