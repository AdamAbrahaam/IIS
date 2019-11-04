export default {
  namespaced: true,
  state: {
    profilePanel: false,
    tournamentPanel: false,
    teamProfilePanel: false,
    teamPanel: false
  },
  mutations: {
    SET_PROFILE_PANEL(state, show) {
      state.profilePanel = show;
    },
    SET_TOURNAMENT_PANEL(state, show) {
      state.tournamentPanel = show;
    },
    SET_TEAM_PANEL(state, show) {
      state.teamPanel = show;
    },
    SET_TEAMPROFILE_PANEL(state, show) {
      state.teamProfilePanel = show;
    }
  },
  actions: {
    async setPanel({ commit, dispatch }, { show, panel, profileId, teamName }) {
      if (profileId) {
        dispatch("user/getProfile", profileId, { root: true });
      } else if (teamName) {
        dispatch("teams/getTeam", teamName, { root: true });
      }

      switch (panel) {
        case "tournamentPanel":
          commit("SET_TOURNAMENT_PANEL", show);
          break;

        case "profilePanel":
          commit("SET_PROFILE_PANEL", show);
          break;

        case "teamPanel":
          commit("SET_TEAM_PANEL", show);
          break;

        case "teamProfilePanel":
          commit("SET_TEAMPROFILE_PANEL", show);
          break;
      }
    }
  }
};
