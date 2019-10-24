<template>
  <v-card>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              v-model="firstName"
              label="First name"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              v-model="lastName"
              label="Last name"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              v-model="email"
              label="E-mail"
              type="e-mail"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              v-model="password"
              :append-icon="showPass ? 'eye-outline' : 'eye-off-outline'"
              :type="showPass ? 'text' : 'password'"
              label="Password"
              required
              @click:append="showPass = !showPass"
            ></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="blue darken-1" text @click="register()">Register</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: "RegisterPanel",
  data() {
    return {
      firstName: "",
      lastName: "",
      email: "",
      password: "",
      showPass: false
    };
  },
  methods: {
    register() {}
  }
};
</script>

<style lang="scss" scoped></style>
