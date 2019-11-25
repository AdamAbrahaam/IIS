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
      return tournaments;
    },
    async getTournament({ commit }, id) {
      let response = await Api()
        .get(`/tournaments/${id}`)
        .catch(error => console.log(error));

      let tournament = response.data;

      commit("SET_TOURNAMENT", tournament);
    },
    async createTournament({ commit, dispatch }, tournamentInfo) {
      try {
        let response = await Api().post(
          "/tournaments/add-tournament",
          tournamentInfo
        );
        let tournament = response.data;

        commit("SET_TOURNAMENT", tournament);
        dispatch("getAll");
        return tournament;
      } catch (exp) {
        return {
          error: "Creation failed! Please try again."
        };
      }
    },
    async addPlayer({ commit }, { userId, tournamentId }) {
      try {
        let response = await Api().put(
          `/tournaments/add-user?userid=${userId}&&tournamentid=${tournamentId}`
        );
        let tournament = response.data;

        commit("SET_TOURNAMENT", tournament);
        return tournament;
      } catch (exp) {
        return {
          error: "Adding user to tournament failed! Please try again."
        };
      }
    },
    async addTeam({ commit }, { teamId, tournamentId }) {
      try {
        let response = await Api().put(
          `/tournaments/add-team?teamid=${teamId}&&tournamentid=${tournamentId}`
        );
        let tournament = response.data;

        commit("SET_TOURNAMENT", tournament);
        return tournament;
      } catch (exp) {
        return {
          error: "Adding user to tournament failed! Please try again."
        };
      }
    },
    async updateTournament(
      { commit, dispatch },
      { tournamentId, updatedInfo }
    ) {
      try {
        let response = await Api().put(
          `/tournaments/${tournamentId}`,
          updatedInfo
        );
        let tournament = response.data;

        commit("SET_TOURNAMENT", tournament);
        dispatch("getAll");
        return tournament;
      } catch (exp) {
        return {
          error: "Update failed! Please try again."
        };
      }
    },
    async deleteTournament({ commit, dispatch }, tournamentId) {
      try {
        let response = await Api().delete(
          `/tournaments/delete?id=${tournamentId}`
        );

        commit("SET_TOURNAMENT", {});
        dispatch("getAll");
        return response;
      } catch (exp) {
        return {
          error: "Delete failed! Please try again."
        };
      }
    },
    async setEditing({ commit }, edit) {
      commit("SET_EDIT", edit);
    }
  },
  getters: {
    upcomingTournaments: state => {
      return state.tournaments.filter(
        t => t.date >= new Date().toJSON().slice(0, 10)
      );
    }
  }
};
