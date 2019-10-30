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
    async setPanel({ commit }, show) {
      commit("SET_PANEL", show);
    }
  }
};
