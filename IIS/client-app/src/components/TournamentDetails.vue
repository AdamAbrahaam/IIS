<template>
  <div class="d-flex flex-wrap justify-center">
    <v-card v-for="item in details" :key="item.name" width="300px" class="ma-3">
      <v-row>
        <v-icon large class="mx-7">{{ item.icon }}</v-icon>
        <v-col
          ><v-row
            ><strong>{{ item.name }}</strong></v-row
          >
          <v-row>{{ item.value }}</v-row></v-col
        >
      </v-row>
    </v-card>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "TournamentDetails",
  computed: {
    ...mapState({
      tournament: state => state.tournaments.tournament
    }),
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
          name: "Date",
          icon: "mdi-calendar-month",
          value: this.tournament.date
        },
        {
          name: "Location",
          icon: "mdi-map-marker",
          value: this.tournament.location
        },
        {
          name: "Type",
          icon: "mdi-account-question",
          value: this.tournament.type ? "Solo" : "Duo"
        },
        {
          name: "Capacity",
          icon: "mdi-account-group",
          value: this.tournament.capacity
        },
        {
          name: "Organizer",
          icon: "mdi-account-star",
          value: this.tournament.organizer.fullName
        },
        {
          name: "Sponsors",
          icon: "mdi-star",
          value: this.tournament.sponsors.join(", ")
        }
      ];
    }
  }
};
</script>

<style scoped></style>
