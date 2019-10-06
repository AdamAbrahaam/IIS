<template>
  <div class="info">{{ info }}</div>
</template>

<script>
import axios from "axios";

export default {
  name: "HelloWorld",

  data() {
    return {
      info: null
    };
  },

  mounted() {
    axios.get("/weatherforecast").then(response => (this.info = response));
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
