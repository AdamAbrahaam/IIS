<template>
  <div>
    <div id="hero">
      <transition appear name="fade">
        <div class="content">
          <p>Create an account, join a tournament and win amazing prices!</p>
          <v-dialog v-model="dialog" overlay-opacity="0.8" max-width="600px">
            <template v-slot:activator="{ on }">
              <v-btn
                x-large
                color="#252423"
                depressed
                dark
                class="mt-8"
                v-on="on"
                >Register now!</v-btn
              >
            </template>
            <RegisterPanel />
          </v-dialog>
        </div>
      </transition>
    </div>

    <div id="tournaments">
      <p class="upcoming">Check out our upcoming tournaments below</p>
      <v-container id="table">
        <v-data-table
          :headers="headers"
          :items="tournaments"
          :sort-desc="[false, true]"
          multi-sort
          :mobile-breakpoint="0"
          hide-default-footer
          class="elevation-5"
        ></v-data-table>
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
        { text: "Entry (€)", value: "entry" },
        { text: "Prize (€)", value: "prize" }
      ]
    };
  },
  computed: {
    ...mapState({
      tournaments: state => state.tournaments.tournaments
    })
  }
};
</script>

<style lang="scss" scoped>
#hero {
  background: url("../static/bg1.jpg") center center;
  background-size: cover;
  height: calc(100vh - 150px);
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
  padding-bottom: 15vh;
  background-image: radial-gradient(
    70% 50% at center,
    rgba(0, 0, 0, 0.5),
    transparent
  );

  p {
    color: #e7e6e3;
    font-weight: 700;
    font-size: 2.3rem;
  }
}

#tournaments {
  max-width: 1440px;
  width: 100%;
  margin: auto;
  margin-top: -100px;
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;

  p {
    color: #e7e6e3;
    font-size: 3rem;
    font-weight: 700;
    margin-bottom: 0;
    background-image: radial-gradient(
      60% 50% at center,
      rgba(0, 0, 0, 0.5),
      transparent
    );
  }

  #table {
    background: white;
    padding: 20px;
  }
}
</style>
