import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    playerStats: [],
    teamStats: []
  },
  mutations: {
    SET_PLAYER_STATS(state, stats) {
      state.playerStats = stats;
    },
    SET_TEAM_STATS(state, stats) {
      state.teamStats = stats;
    }
  },
  actions: {
    async getAllUserStats({ commit }) {
      try {
        let response = await Api().get("/statistics/users_ranking");

        let stats = response.data;

        commit("SET_PLAYER_STATS", stats);
        return stats;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    },
    async getAllTeamStats({ commit }) {
      try {
        let response = await Api().get("/statistics/teams_ranking");

        let stats = response.data;

        commit("SET_TEAM_STATS", stats);
        return stats;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    }
  }
};
