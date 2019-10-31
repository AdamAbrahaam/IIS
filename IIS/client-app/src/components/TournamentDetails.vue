<template>
  <div>
    <v-card class="mx-3 my-7 pr-7 mx-sm-12 elevation-5">
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
    <div class="d-flex flex-wrap justify-center">
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
      editingState: state => state.tournaments.editing
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
          name: "Sponsors",
          icon: "mdi-star",
          value: this.tournament.sponsors
        }
      ];
    }
  },
  methods: {
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
    async update() {
      this.$store.dispatch("tournaments/setEditing", false);
      let updatedInfo = {};
      updatedInfo.Info = this.tournament.info;
      updatedInfo.Name = this.tournament.name;
      updatedInfo.tournamentId = this.tournament.tournamentId;
      this.details.forEach(element => {
        updatedInfo[element.name] = element.value;
      });

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
