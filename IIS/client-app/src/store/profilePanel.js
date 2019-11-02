export default {
  namespaced: true,
  state: {
    showing: false
  },
  mutations: {
    SET_PANEL(state, show) {
      state.showing = show;
    }
  },
  actions: {
    async setPanel({ commit, dispatch }, { show, profileId }) {
      if (profileId) {
        dispatch("user/getProfile", profileId, { root: true });
      }

      commit("SET_PANEL", show);
    }
  }
};
