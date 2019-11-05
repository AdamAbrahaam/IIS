import Vue from "vue";
import Vuex from "vuex";
import tournamentsModule from "./tournaments";
import userModule from "./user";
import statisticsModule from "./statistics";
import panelsModule from "./panels";
import teamModule from "./teams";
import matchesModule from "./matches";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    tournaments: tournamentsModule,
    user: userModule,
    statistics: statisticsModule,
    panels: panelsModule,
    teams: teamModule,
    matches: matchesModule
  }
});
