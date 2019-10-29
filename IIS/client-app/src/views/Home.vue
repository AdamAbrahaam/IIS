<template>
  <div>
    <v-dialog v-model="dialog" overlay-opacity="0.8" max-width="600px">
      <RegisterPanel v-bind:closeModal="closeModal" />
    </v-dialog>

    <div id="hero">
      <transition appear name="fade">
        <div class="content">
          <p>Join a tournament and win amazing prizes!</p>
          <v-btn
            v-if="!currentUser.email"
            x-large
            color="#252423"
            depressed
            dark
            class="mt-8"
            @click.stop="dialog = true"
            >Register now!</v-btn
          >
        </div>
      </transition>
    </div>

    <div id="tournaments">
      <img src="../static/logo3.png" />
      <p class="upcoming">Check out our upcoming tournaments below</p>
      <a v-scroll-to="'#table'">
        <v-icon size="80px" color="black" class="mt-n10"
          >mdi-menu-down</v-icon
        ></a
      >
      <v-container id="table">
        <v-data-table
          :headers="headers"
          :items="tournaments"
          :sort-desc="[false, true]"
          multi-sort
          :mobile-breakpoint="0"
          hide-default-footer
          class="elevation-5"
          @click:row="
            $router.push({
              name: 'tournament',
              params: { tournamentId: $event.tournamentId }
            })
          "
        >
          <template v-slot:item.type="{ item }">
            <v-icon>{{
              item.type ? "mdi-account-multiple" : "mdi-account"
            }}</v-icon>
          </template>
          <template v-slot:item.entry="{ item }">
            {{ item.entry }}€
          </template>
          <template v-slot:item.prize="{ item }">
            {{ item.prize }}€
          </template></v-data-table
        >
      </v-container>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
import RegisterPanel from "@/components/RegisterPanel.vue";

export default {
  name: "Home",
  components: {
    RegisterPanel
  },
  data() {
    return {
      dialog: false,
      headers: [
        { text: "Name", value: "name" },
        { text: "Date", value: "date" },
        { text: "Location", value: "location" },
        { text: "Type", value: "type" },
        { text: "Entry", value: "entry" },
        { text: "Prize", value: "prize" }
      ]
    };
  },
  computed: {
    ...mapState({
      tournaments: state => state.tournaments.tournaments,
      currentUser: state => state.user.currentUser
    })
  },
  methods: {
    closeModal() {
      this.dialog = false;
    }
  }
};
</script>

<style lang="scss" scoped>
@import url("https://fonts.googleapis.com/css?family=Raleway&display=swap");

#hero {
  background: url("../static/bg1.jpg") center center;
  background-size: cover;
  height: calc(100vh - 300px);
}

.fade-enter-active {
  transition: all 1.5s ease-out;
}

.fade-enter {
  opacity: 0;
  letter-spacing: 0.1em;
}

.fade-enter-to {
  opacity: 1;
}

.content {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100%;
  padding-bottom: 10vh;
  background-image: radial-gradient(
    70% 50% at center,
    rgba(0, 0, 0, 0.6),
    transparent
  );

  p {
    color: white;
    font-size: 2.8rem;
    font-family: "Raleway", sans-serif;
    text-transform: uppercase;
    letter-spacing: 0.012em;
  }
}

#tournaments {
  max-width: 1440px;
  width: 100%;
  margin: auto;
  margin-top: -120px;
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;

  img {
    height: 250px;
  }

  p {
    color: black;
    font-size: 2.5rem;
    font-family: "Raleway", sans-serif;
    text-transform: uppercase;
  }

  #table {
    background: white;
    padding: 20px;
  }
}
</style>
