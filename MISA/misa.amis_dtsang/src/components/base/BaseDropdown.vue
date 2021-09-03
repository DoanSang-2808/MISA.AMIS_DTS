<template>
  <div class="dropdown">
    <!-- <div class="dropdown-wrapper">
      <div class="input">
        <input type="text" />
      </div>
      <div class="icon-drop">
        <div class="icon"></div>
      </div>
    </div> -->
    <!-- <div class="menu-item"> -->
      <select class="form-control">
      <option
        class="item"
        v-for="department of departments"
        :key="department.id"
        :value="department.departmentId"
      >
        {{ department.departmentName }}
      </option>
      </select>
    <!-- </div> -->
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Dropdown",
  components: {},
  data() {
    return {
      departments: [],
    };
  },
  created() {
    //this.getDepartment();
  },
  methods: {
    /**
     * Phương thức lấy các đơn vị
     * Author: DTsang(30/08)
     */
    getDepartment() {
      let self = this;
      axios
        .get("https://localhost:5001/api/Department")
        .then((response) => {
          self.departments = response.data.data;
          console.log(this.departments);
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
</script>

<style scoped>
.dropdown{
    height: 50%;
    width: 100%;
    border: 1px solid #ccc;
    border-radius: 4px;
}
select{
    height:100%;
    width: 100%;
    border: none;
}
option{
    height: 32px;
}
/* .dropdown:hover .menu-item{
    display: block;
}
.dropdown-wrapper {
  width: 100%;
  height: 50%;
  border-radius: 4px;
  border: 1px solid #bbb;
  display: flex;
  align-items: center;
}
.dropdown-wrapper .input {
  width: 95%;
  height: 100%;
  position: relative;
  display: flex;
  align-content: center;
}
.dropdown-wrapper .input input {
  width: 100%;
  outline: none;
  border: none;
  margin-left: 10px;
}
.menu-item {
  display: none;
  width: 100%;
  border: 1px solid #ccc;
  position: absolute;
  top: 36px;
  background-color: #fff;
  z-index: 2;
  border-radius: 4px;
}
.menu-item .item {
  height: 32px;
  border-bottom: 1px solid #ccc;
}
.dropdown-wrapper .icon-drop {
  width: 5%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}
.dropdown-wrapper .icon-drop .icon {
  width: 16px;
  height: 16px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -369px -361px;
} */
</style>
