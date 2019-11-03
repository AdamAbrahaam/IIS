export default {
  namespaced: true,
  state: {
    profilePanel: false,
    tournamentPanel: false,
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
    }
  },
  actions: {
    async setPanel({ commit, dispatch }, { show, panel, profileId }) {
      if (profileId) {
        dispatch("user/getProfile", profileId, { root: true });
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
      }
    }
  }
};
