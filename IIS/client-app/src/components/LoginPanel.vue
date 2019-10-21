<template>
  <v-card>
    <v-card-text>
      <v-container>
        <v-row>
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
              label="Password"
              type="password"
              required
            ></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="blue darken-1" text @click="login()">Login</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: 'LoginPanel',
  data() {
    return {
      email: '',
      password: ''
    }
  },
  methods: {
    login() {}
  }
}
</script>
