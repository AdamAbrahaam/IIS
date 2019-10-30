import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    tournaments: [],
    editing: false,
    tournament: {}
  },
  mutations: {
    SET_TOURNAMENTS(state, tournaments) {
      state.tournaments = tournaments;
    },
    SET_TOURNAMENT(state, tournament) {
      state.tournament = tournament;
    },
    SET_EDIT(state, edit) {
      state.editing = edit;
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
        return tournament;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    },
    /*async updateTournament({ commit }, updatedInfo) {
      try {
        let response = await Api().post(
          "/tournaments/",
          tournamentInfo
        );
        let tournament = response.data;

        commit("SET_TOURNAMENT", tournament);
        return tournament;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    },*/
    async setEditing({ commit }, edit) {
      commit("SET_EDIT", edit);
    }
  }
};
