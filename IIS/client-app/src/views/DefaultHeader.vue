<template>
  <div>
    <div id="header">
      <slot name="title"></slot>
    </div>
    <slot></slot>
  </div>
</template>

<script>
export default {
  name: "DefaultHeader"
};
</script>

<style lang="scss" scoped>
#header {
  background: url("../static/header.png") center;
  background-size: cover;
  height: 30vh;

  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;

  color: #3bf8f7;
  font-size: 3rem;
  font-weight: bold;
  font-family: "Fifa Font", sans-serif;
  letter-spacing: 0.05em;
}
</style>
