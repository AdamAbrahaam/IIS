<template>
  <div>
    <v-card
      v-if="
        !tournament.referee &&
          currentUser.fullName &&
          currentUser.fullName !== tournament.organizer
      "
      class="mt-5 mx-5 py-3 d-flex flex-column justify-center align-center"
      color="error"
      @click="update(currentUser.fullName)"
    >
      <div class="white--text display-1 font-weight-bold">
        !!! Referee needed !!!
      </div>
      <div class="white--text">Click to join as a referee!</div>
    </v-card>
    <div class="display-1 mt-8 mx-5">Participants</div>
    <v-divider class="my-2"></v-divider>
    <div class="d-flex justify-center flex-wrap">
      <div v-if="tournament.participants.length">
        <v-chip
          v-for="participant in tournament.participants"
          :key="participant.participantId"
          class="ma-2"
          color="indigo"
          text-color="white"
          @click="participiantInfo(participant.userOrTeam, participant.isUser)"
        >
          <v-avatar left>
            <v-icon v-if="participant.isUser">mdi-account-circle</v-icon>
            <v-icon v-else>mdi-account-supervisor-circle</v-icon>
          </v-avatar>
          {{ participant.name }}
        </v-chip>
      </div>
      <div v-else class="grey--text">
        No participants yet!
      </div>
    </div>

    <div class="display-1 mt-10 mx-5">Details</div>
    <v-divider class="my-2"></v-divider>
    <v-card v-if="tournament.info" class="mx-3 my-7 pr-7 mx-sm-12 elevation-5">
      <v-row>
        <v-icon large class="mx-7 mt-7 d-flex align-self-start"
          >mdi-square-edit-outline</v-icon
        >
        <v-col>
          <v-row>
            <v-textarea
              ref="tournament.info"
              v-model="tournament.info"
              :outlined="!isEditing"
              :flat="isEditing"
              :solo="isEditing"
              name="tournament.info"
              :value="tournament.info"
              :readonly="isEditing"
              auto-grow
              class="ml-n4 mb-n7"
            ></v-textarea></v-row
        ></v-col>
      </v-row>
    </v-card>
    <div class="d-flex flex-wrap justify-center mb-12">
      <v-card
        v-for="item in details"
        :key="item.name"
        width="300px"
        class="ma-3 elevation-5"
      >
        <v-row>
          <v-icon large class="ml-7 mr-2">{{ item.icon }}</v-icon>
          <v-col
            ><v-row
              ><strong class="pl-3">{{ item.name }}</strong></v-row
            >
            <v-row
              ><v-text-field
                ref="item.value"
                v-model="item.value"
                class="pr-7 mb-n9"
                :value="item.value"
                :outlined="!isEditing"
                :flat="isEditing"
                :solo="isEditing"
                :readonly="isEditing"
              ></v-text-field></v-row
          ></v-col>
        </v-row>
      </v-card>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "TournamentDetails",
  computed: {
    ...mapState({
      tournament: state => state.tournaments.tournament,
      editingState: state => state.tournaments.editing,
      matches: state => state.matches.matches,
      currentUser: state => state.user.currentUser
    }),
    isEditing() {
      return !this.editingState;
    },
    details() {
      return [
        {
          name: "Prize",
          icon: "mdi-trophy",
          value: this.tournament.prize + "€"
        },
        {
          name: "Entry",
          icon: "mdi-cash",
          value: this.tournament.entry + "€"
        },
        {
          name: "Capacity",
          icon: "mdi-account-group",
          value: this.tournament.capacity
        },
        {
          name: "Date",
          icon: "mdi-calendar-month",
          value: this.tournament.date
        },
        {
          name: "Time",
          icon: "mdi-clock",
          value: this.tournament.time
        },
        {
          name: "Location",
          icon: "mdi-map-marker",
          value: this.tournament.location
        },
        {
          name: "Type",
          icon: "mdi-account-question",
          value: this.tournament.type
        },
        {
          name: "Organizer",
          icon: "mdi-account-star",
          value: this.tournament.organizer
        },
        {
          name: "Referee",
          icon: "mdi-account-alert",
          value: this.tournament.referee ? this.tournament.referee : "TBA"
        },
        {
          name: "Sponsors",
          icon: "mdi-star",
          value: this.tournament.sponsors
        }
      ];
    }
  },
  methods: {
    participiantInfo(id, isUser) {
      console.log(id);
      if (isUser) {
        this.$store.dispatch("panels/setPanel", {
          show: true,
          panel: "profilePanel",
          profileId: id
        });
      } else {
        this.$store.dispatch("panels/setPanel", {
          show: true,
          panel: "teamProfilePanel",
          teamName: id
        });
      }
    },
    deleteEur() {
      this.details[0].value = this.details[0].value.substring(
        0,
        this.details[0].value.length - 1
      );
      this.details[1].value = this.details[1].value.substring(
        0,
        this.details[1].value.length - 1
      );
    },
    async update(referee) {
      this.$store.dispatch("tournaments/setEditing", false);

      let updatedInfo = {};
      updatedInfo.Info = this.tournament.info;
      updatedInfo.Name = this.tournament.name;
      updatedInfo.TournamentId = this.tournament.tournamentId;
      this.details.forEach(element => {
        updatedInfo[element.name] = element.value;
      });
      updatedInfo["Prize"] = updatedInfo["Prize"].replace("€", "");
      updatedInfo["Entry"] = updatedInfo["Entry"].replace("€", "");
      updatedInfo["Referee"] = this.tournament.referee;
      updatedInfo["Organizer"] = this.tournament.organizer;

      if (referee) {
        updatedInfo.Referee = referee;
      }
      if (updatedInfo.Referee === "TBA") {
        updatedInfo.Referee = null;
      }
      this.details[0].value += "€";
      this.details[1].value += "€";

      await this.$store.dispatch("tournaments/updateTournament", {
        tournamentId: this.tournament.tournamentId,
        updatedInfo: updatedInfo
      });
    }
  }
};
</script>

<style scoped></style>
