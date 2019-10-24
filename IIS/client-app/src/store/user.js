import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    users: [],
    currentUser: {}
  },
  mutations: {
    SET_CURRENT_USER(state, user) {
      state.currentUser = user;
      window.localStorage.currentUser = JSON.stringify(user);
    },
    LOGOUT_USER(state) {
      state.currentUser = {};
      window.localStorage.currentUser = JSON.stringify({});
    }
  },
  actions: {
    async login({ commit }, loginInfo) {
      try {
        let response = await Api().get(
          "/users/user-by-email?email=" + loginInfo.email
        );
        let user = response.data;

        commit("SET_CURRENT_USER", user);
        return user;
      } catch {
        return {
          error: "Email/password combination was incorrect.  Please try again."
        };
      }
    },
    logout({ commit }) {
      commit("LOGOUT_USER");
    }
  }
};
