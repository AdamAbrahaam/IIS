<template>
  <v-app id="inspire">
    <v-app-bar flat max-height="90px" color="#252423">
      <v-app-bar-nav-icon class="hidden-md-and-up" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>

      <v-btn
        class="hidden-sm-and-down logo-btn"
        text
        nuxt
        color="#e7e6e3"
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
      >
        <span class="mr-2 display-1">Fifka</span>
      </v-btn>
      <v-spacer></v-spacer>
      <v-btn
        class="hidden-sm-and-down"
        text
        nuxt
        color="#e7e6e3"
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
      >
        <span class="mr-2">button1</span>
      </v-btn>
      <v-btn
        class="hidden-sm-and-down"
        text
        nuxt
        color="#e7e6e3"
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
      >
        <span class="mr-2">button2</span>
      </v-btn>
      <v-btn
        class="hidden-sm-and-down"
        text
        nuxt
        color="#e7e6e3"
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
      >
        <span class="mr-2">button3</span>
      </v-btn>
      <v-btn
        class="hidden-sm-and-down"
        text
        nuxt
        color="#e7e6e3"
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
      >
        <span class="mr-2">button4</span>
      </v-btn>

      <v-dialog v-model="dialog" overlay-opacity="0.8" max-width="600px">
        <template v-slot:activator="{ on }">
          <v-btn class="white--text hidden-sm-and-down" outlined color="#e7e6e3" v-on="on">
            <span>Login</span>
          </v-btn>
        </template>
        <LoginPanel />
      </v-dialog>
    </v-app-bar>

    <v-navigation-drawer id="drawer" v-model="drawer" temporary absolute width="100vw"></v-navigation-drawer>

    <v-content>
      <Home />
    </v-content>

    <!-- <v-footer :fixed="fixed" app>
      <span>&copy; 2019</span>
    </v-footer>-->
  </v-app>
</template>

<script>
import LoginPanel from "@/components/LoginPanel.vue";
import Home from "@/views/Home.vue";

export default {
  name: "App",
  components: {
    LoginPanel,
    Home
  },
  data: () => ({
    drawer: null,
    dialog: false
  })
};
</script>

<style>
.v-data-table th {
  font-size: 24px !important;
  color: #252423 !important;
  padding: 25px 0px 25px 20px !important;
}

.v-data-table td {
  font-size: 18px !important;
  padding: 25px !important;
}

#inspire {
  background: none;
}

.logo-btn::before {
  color: transparent;
}

.logo-btn:hover {
  color: transparent;
}
</style>

