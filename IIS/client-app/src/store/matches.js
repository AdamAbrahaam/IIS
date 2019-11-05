import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    matches: []
  },
  mutations: {
    SET_MATCHES(state, matches) {
      state.matches = matches;
    }
  },
  actions: {
    async getMatches({ commit }, tournamentId) {
      try {
        let response = await Api().get(`/matches/tournament/${tournamentId}`);

        let matches = response.data;

        commit("SET_MATCHES", matches);
        return matches;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    },
    async addMatch({ dispatch }, matchInfo) {
      try {
        console.log(matchInfo);
        let response = await Api().post("/matches/solo_match", matchInfo);

        let stats = response.data;

        dispatch("getMatches", matchInfo.TournamentId);
        return stats;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    }
  }
};
