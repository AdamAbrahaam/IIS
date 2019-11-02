import Vue from "vue";
import Vuex from "vuex";
import tournamentsModule from "./tournaments";
import userModule from "./user";
import tournamentPanelModule from "./tournamentPanel";
import statisticsModule from "./statistics";
import profilePanelModule from "./profilePanel";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    tournaments: tournamentsModule,
    user: userModule,
    tournamentPanel: tournamentPanelModule,
    statistics: statisticsModule,
    profilePanel: profilePanelModule
  }
});
