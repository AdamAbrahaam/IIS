import Vue from "vue";
import Vuex from "vuex";
import tournamentsModule from "./tournaments";
import userModule from "./user";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    tournaments: tournamentsModule,
    user: userModule
  }
});
