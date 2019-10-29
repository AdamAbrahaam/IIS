import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    tournaments: [],
    tournament: {}
  },
  mutations: {
    SET_TOURNAMENTS(state, tournaments) {
      state.tournaments = tournaments;
    },
    SET_TOURNAMENT(state, tournament) {
      state.tournament = tournament;
    }
  },
  actions: {
    async getAll({ commit }) {
      let response = await Api()
        .get("/tournaments")
        .catch(error => console.log(error));

      let tournaments = response.data;

      commit("SET_TOURNAMENTS", tournaments);
    },
    async getTournament({ commit }, id) {
      let response = await Api()
        .get(`/tournaments/${id}`)
        .catch(error => console.log(error));

      let tournament = response.data;

      commit("SET_TOURNAMENT", tournament);
    },
    async createTournament({ commit }, tournamentInfo) {
      try {
        let response = await Api().post(
          "/tournaments/add-tournament",
          tournamentInfo
        );
        let tournament = response.data;

        commit("SET_TOURNAMENT", tournament);
        this.$router.push({
          name: "tournament",
          params: { tournamentId: tournament.tournamentId }
        });
      } catch {
        return {
          error: "Registration failed! Please try again."
        };
      }
    }
  }
};
