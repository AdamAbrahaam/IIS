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
        let response = await Api().post(
          `/matches/solo_match?userid1=${matchInfo.Home}&&userid2=${matchInfo.Away}&&tournamentid=${matchInfo.TournamentId}`
        );

        let match = response.data;

        dispatch("getMatches", matchInfo.TournamentId);
        return match;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    }
  }
};
