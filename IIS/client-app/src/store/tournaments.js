import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    tournaments: []
  },
  mutations: {
    SET_TOURNAMENTS(state, tournaments) {
      state.tournaments = tournaments;
    }
  },
  actions: {
    async getAll({ commit }) {
      let response = await Api()
        .get("/tournaments")
        .catch(error => console.log(error));

      let tournaments = response.data;

      commit("SET_TOURNAMENTS", tournaments);
    }
  }
};
