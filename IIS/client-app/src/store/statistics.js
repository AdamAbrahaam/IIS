import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    playerStats: [],
    teamStats: [],
    participantStats: {}
  },
  mutations: {
    SET_PLAYER_STATS(state, stats) {
      state.playerStats = stats;
    },
    SET_TEAM_STATS(state, stats) {
      state.teamStats = stats;
    },
    SET_PARTICIPANT_STATS(state, stats) {
      state.participantStats = stats;
    }
  },
  actions: {
    async userTournamentStats({ commit }, { userId, tournamentId }) {
      try {
        let response = await Api().get(
          `/users/user-stats-in-tournament?userid=${userId}&&tournamentid=${tournamentId}`
        );

        let stats = response.data;
        commit("SET_PARTICIPANT_STATS", stats);

        return stats;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    },
    async teamTournamentStats({ commit }, { name, tournamentId }) {
      try {
        let response = await Api().get(
          `/teams/stats-for-team-in-tournament?name=${name}&&tournamentid=${tournamentId}`
        );

        let stats = response.data;
        commit("SET_PARTICIPANT_STATS", stats);
        return stats;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    },
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
