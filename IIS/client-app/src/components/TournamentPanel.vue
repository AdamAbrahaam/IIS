<template>
  <v-card>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              ref="tournamentInfo.name"
              v-model="tournamentInfo.name"
              label="Name"
              type="text"
              required
              prepend-icon="mdi-format-letter-case"
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              ref="tournamentInfo.location"
              v-model="tournamentInfo.location"
              label="Location"
              type="text"
              required
              prepend-icon="mdi-map-marker"
            ></v-text-field>
          </v-col>
          <v-col cols="12" class="d-flex flex-wrap">
            <v-text-field
              ref="tournamentInfo.prize"
              v-model="tournamentInfo.prize"
              label="Prize"
              type="text"
              required
              suffix="€"
              prepend-icon="mdi-trophy"
              class="mr-sm-3"
            ></v-text-field>
            <v-text-field
              ref="tournamentInfo.entry"
              v-model="tournamentInfo.entry"
              label="Entry"
              type="text"
              required
              suffix="€"
              prepend-icon="mdi-cash"
            ></v-text-field>
          </v-col>
          <v-col cols="12" class="d-flex flex-wrap">
            <v-combobox
              v-model="tournamentInfo.capacity"
              :items="allowedCapacity"
              label="Capacity"
              prepend-icon="mdi-account-group"
              class="mr-sm-3"
            ></v-combobox>
            <v-combobox
              v-model="tournamentInfo.type"
              :items="types"
              label="Type"
              prepend-icon="mdi-account-question"
            ></v-combobox>
          </v-col>
          <v-col cols="12" class="d-flex flex-wrap justify-space-between">
            <v-menu
              ref="dateMenu"
              v-model="dateMenu"
              :close-on-content-click="false"
              transition="scale-transition"
              offset-y
              min-width="290px"
            >
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-model="date"
                  label="Date"
                  prepend-icon="mdi-calendar"
                  v-on="on"
                  class="mr-sm-3"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="date"
                :min="new Date().toISOString().substr(0, 10)"
                no-title
                @input="dateMenu = false"
              ></v-date-picker>
            </v-menu>

            <v-menu
              ref="timeMenu"
              v-model="timeMenu"
              :close-on-content-click="false"
              transition="scale-transition"
              offset-y
              max-width="290px"
              min-width="290px"
            >
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-model="time"
                  label="Time"
                  prepend-icon="mdi-clock"
                  readonly
                  v-on="on"
                ></v-text-field>
              </template>
              <v-time-picker
                v-if="timeMenu"
                v-model="time"
                format="24hr"
                @click:minute="$refs.timeMenu.save(time)"
              ></v-time-picker>
            </v-menu>
          </v-col>
          <v-col cols="12">
            <v-text-field
              ref="tournamentInfo.sponsors"
              v-model="tournamentInfo.sponsors"
              label="Sponsors"
              type="text"
              required
              prepend-icon="mdi-account-star"
            ></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="blue darken-1" text @click="createTournament()"
        >Create tournament</v-btn
      >
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: "TournamentPanel",
  props: ["closeModal"],
  data() {
    return {
      date: null,
      dateMenu: false,
      time: null,
      timeMenu: false,
      tournamentInfo: {
        name: null,
        location: null,
        date: null,
        prize: null,
        entry: null,
        capacity: null,
        type: null,
        sponsors: null,
        organizer: this.currentUser
      },
      types: ["Solo", "Duo"],
      allowedCapacity: [2, 4, 8, 16]
    };
  },
  methods: {
    createTournament() {}
  }
};
</script>

<style lang="scss" scoped></style>
