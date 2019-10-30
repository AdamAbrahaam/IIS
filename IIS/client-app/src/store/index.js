import Vue from "vue";
import Vuex from "vuex";
import tournamentsModule from "./tournaments";
import userModule from "./user";
import tournamentPanelModule from "./tournamentPanel";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    tournaments: tournamentsModule,
    user: userModule,
    tournamentPanel: tournamentPanelModule
  }
});
