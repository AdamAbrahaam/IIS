import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    editing: false,
    team: [],
    teamStats: {},
    members: []
  },
  mutations: {
    SET_TEAM(state, team) {
      state.team = team;
    },
    SET_EDIT(state, edit) {
      state.editing = edit;
    },
    SET_TEAM_STATS(state, stats) {
      state.teamStats = stats;
    },
    SET_MEMBERS(state, usersInTeam) {
      state.members = usersInTeam;
    }
  },
  actions: {
    async getTeam({ commit, dispatch }, teamName) {
      let response = await Api()
        .get(`/teams/${teamName}`)
        .catch(error => console.log(error));

      let team = response.data;

      commit("SET_TEAM", team);
      dispatch("getStatsForTeam", teamName);
      dispatch("getUsersInTeam", teamName);
      return team;
    },
    async getStatsForTeam({ commit }, teamName) {
      try {
        let response = await Api().get(`/teams/stats-for-team/${teamName}`);

        let stats = response.data;

        commit("SET_TEAM_STATS", stats);
        return stats;
      } catch (exp) {
        return {
          error: "Getting stats for team failed! Please try again."
        };
      }
    },
    async getUsersInTeam({ commit }, teamName) {
      try {
        let response = await Api().get(`/teams/users-in-team/${teamName}`);

        let usersInTeam = response.data;

        commit("SET_MEMBERS", usersInTeam);
        return usersInTeam;
      } catch (exp) {
        return {
          error: "Getting users in team failed! Please try again."
        };
      }
    },
    async createTeam({ commit, dispatch }, { teamInfo, userId }) {
      try {
        console.log(teamInfo);
        let response = await Api().post("/teams", teamInfo);
        let team = response.data;

        commit("SET_TEAM", team);
        dispatch("addUser", { userId: userId, teamName: team.name });
        return team;
      } catch (exp) {
        console.log(exp);
        return {
          error: "Creation failed! Please try again."
        };
      }
    },
    async addUser({ commit }, { userId, teamName }) {
      try {
        let response = await Api().put(
          `/teams/add-user?userid=${userId}&&team=${teamName}`
        );
        let team = response.data;
        commit("SET_TEAM", team);
        return team;
      } catch (exp) {
        return {
          error: "Adding user to team failed! Please try again."
        };
      }
    },
    async removeUser({ commit, dispatch }, tournamentId) {
      try {
        let response = await Api().delete(`/tournaments/${tournamentId}`);

        commit("SET_TOURNAMENT", {});
        dispatch("getAll");
        return response;
      } catch (exp) {
        console.log(exp);
        return {
          error: "Delete failed! Please try again."
        };
      }
    },
    async setEditing({ commit }, edit) {
      commit("SET_EDIT", edit);
    }
  }
};
