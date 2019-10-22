import Api from "../services/api";

export default {
  state: {
    users: [],
    currentUser: {}
  },
  mutations: {
    SET_CURRENT_USER(state, user) {
      state.currentUser = user;
      window.localStorage.currentUser = JSON.stringify(user);
    }
  },
  actions: {
    async login({ commit }, loginInfo) {
      try {
        let response = await Api().post("/login", loginInfo);
        let user = response.data.data.attributes;

        commit("SET_CURRENT_USER", user);
        return user;
      } catch {
        return {
          error: "Email/password combination was incorrect.  Please try again."
        };
      }
    }
  }
};
