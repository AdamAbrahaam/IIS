<template>
  <v-card>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              ref="tournamentInfo.name"
              v-model="tournamentInfo.name"
              label="Name*"
              type="text"
              required
              :rules="[rules.required]"
              prepend-icon="mdi-format-letter-case"
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              ref="tournamentInfo.location"
              v-model="tournamentInfo.location"
              label="Location*"
              type="text"
              required
              :rules="[rules.required]"
              prepend-icon="mdi-map-marker"
            ></v-text-field>
          </v-col>
          <v-col cols="12" class="d-flex flex-wrap">
            <v-text-field
              ref="tournamentInfo.prize"
              v-model="tournamentInfo.prize"
              label="Prize*"
              type="text"
              required
              :rules="[rules.required, rules.number]"
              suffix="€"
              prepend-icon="mdi-trophy"
              class="mr-sm-3"
            ></v-text-field>
            <v-text-field
              ref="tournamentInfo.entry"
              v-model="tournamentInfo.entry"
              label="Entry*"
              type="text"
              :rules="[rules.required, rules.number]"
              required
              suffix="€"
              prepend-icon="mdi-cash"
            ></v-text-field>
          </v-col>
          <v-col cols="12" class="d-flex flex-wrap">
            <v-combobox
              v-model="tournamentInfo.capacity"
              :items="allowedCapacity"
              label="Capacity*"
              :rules="[rules.required, rules.capacity]"
              prepend-icon="mdi-account-group"
              class="mr-sm-3"
            ></v-combobox>
            <v-combobox
              v-model="tournamentInfo.type"
              :items="types"
              label="Type*"
              :rules="[rules.required, rules.type]"
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
                  v-model="tournamentInfo.date"
                  label="Date*"
                  prepend-icon="mdi-calendar"
                  v-on="on"
                  readonly
                  :rules="[rules.required]"
                  class="mr-sm-3"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="tournamentInfo.date"
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
                  v-model="tournamentInfo.time"
                  label="Time*"
                  :rules="[rules.required]"
                  prepend-icon="mdi-clock"
                  readonly
                  v-on="on"
                ></v-text-field>
              </template>
              <v-time-picker
                v-if="timeMenu"
                v-model="tournamentInfo.time"
                format="24hr"
                @click:minute="$refs.timeMenu.save(tournamentInfo.time)"
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
          <v-col cols="12">
            <v-textarea
              ref="tournamentInfo.info"
              v-model="tournamentInfo.info"
              solo
              no-resize
              prepend-inner-icon="mdi-square-edit-outline"
              name="tournamentInfo.info"
              label="Write additional information here..."
            ></v-textarea>
          </v-col>
          <v-col
            cols="12"
            v-show="this.tournament.error"
            class="my-n7 red--text text-center"
          >
            {{ this.tournament.error }}
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="blue darken-1" text @click="close()">Close</v-btn>
      <v-btn v-if="isEditing" color="blue darken-1" text @click="update()"
        >Save</v-btn
      >
      <v-btn v-else color="blue darken-1" text @click="createTournament()"
        >Create tournament</v-btn
      >
    </v-card-actions>
  </v-card>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "TournamentPanel",
  props: ["closeModal", "editInfo", "isEditing"],
  data() {
    return {
      dateMenu: false,
      timeMenu: false,
      tournament: {},
      types: ["Solo", "Duo"],
      allowedCapacity: [2, 4, 8, 16],
      tournamentInfo: {
        name: null,
        location: null,
        date: new Date().toJSON().slice(0, 10),
        time: new Date().toTimeString().slice(0, 5),
        prize: null,
        entry: null,
        capacity: null,
        type: null,
        sponsors: null,
        organizer: null,
        info: null
      },
      rules: {
        required: v => !!v || "This field is required!",
        number: v => !isNaN(v) || "Invalid number!",
        type: v => !(v !== "Solo" && v !== "Duo") || "Incorrect type!",
        capacity: v =>
          !(v !== 2 && v !== 4 && v !== 8 && v !== 16) ||
          "Incorrect capacity number!"
      }
    };
  },
  computed: {
    ...mapState({
      currentUser: state => state.user.currentUser
    })
  },
  methods: {
    async createTournament() {
      let isInError = document.getElementsByClassName("v-messages__message");
      if (isInError.length != 0) {
        console.log(isInError.length);
        this.tournament.error = "Invalid field(s)!";
        return;
      }

      this.tournamentInfo.organizer = this.currentUser.fullName;
      this.tournament = await this.$store.dispatch(
        "tournaments/createTournament",
        this.tournamentInfo
      );

      if (!this.tournament.error) {
        this.tournamentInfo = {};
        this.$store.dispatch("panels/setPanel", {
          show: false,
          panel: "tournamentPanel",
          profileId: null
        });
        this.$router.push({
          name: "tournament",
          params: { tournamentId: this.tournament.tournamentId }
        });
      }
    },
    close() {
      this.$store.dispatch("panels/setPanel", {
        show: false,
        panel: "tournamentPanel",
        profileId: null
      });
      this.$store.dispatch("tournaments/setEditing", false);
    }
  }
};
</script>

<style lang="scss" scoped></style>
