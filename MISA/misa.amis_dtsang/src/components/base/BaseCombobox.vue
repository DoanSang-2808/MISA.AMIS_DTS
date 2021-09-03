<template>
  <div class="combobox" @click="toggleCombobox">
    <div class="combobox-search flex">
      <ValidationProvider
        tag="div"
        style="width: 100%"
        rules="required"
        name="Đơn vị"
        v-slot="{ errors }"
      >
        <input
          type="text"
          class="width-100"
          v-model="keysearch"
          :class="{
            'border-red': errors.length > 0 ? true : false,
          }"
          :title="errors[0]"
        />
      </ValidationProvider>
      <div class="combobox-icon">
        <div class="btn-combobox"></div>
      </div>
    </div>
    <div class="combobox-data" :class="{ 'show-combobox': isShow }">
      <table>
        <thead>
          <tr>
            <th style="width: 100%">Tên đơn vị</th>
          </tr>
        </thead>
        <tbody v-if="value != null">
          <tr
            v-for="(department, index) in departments"
            :key="index"
            @click="chooseDepartment(index)"
            :class="{
              'combobox-active':
                item.departmentId == department.departmentId ? true : false,
            }"
          >
            <td>{{ department.departmentName }}</td>
          </tr>
        </tbody>
        <tbody v-else-if="value == null">
          <tr
            v-for="(department, index) in options"
            :key="index"
            @click="chooseDepartment(index)"
          >
            <td>{{ department.departmentName }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Combobox",
  props: ["value"],
  data() {
    return {
      isShow: false,
      departments: [],
      item: {},
      options: [],
      keysearch: "",
    };
  },
  created() {
    this.getDepartment();
  },
  watch: {
    /**
     * Hàm theo dõi sư thay đổi của giá trị keysearch
     * Author: DTSang(31/08)
     */
    // keysearch() {
    //   this.searchDepartment();
    // },
    /**
     * HÀm theo dõi sự thay đổi của giá trị value
     * Author: DTSang(31/08)
     */
    value() {
      this.setValue();
    },
  },
  methods: {
    toggleCombobox() {
      this.isShow = !this.isShow;
    },

    /**-------------------------------------------------------------
     * Hàm lấy tất cả các đơn vị
     * Author: DTSang(31/08)
     */
    getDepartment() {
      var self = this;
      axios.get("https://localhost:5001/api/Departments").then((response) => {
        self.departments = response.data.data;
        self.options = response.data.data;
        console.log(this.departments);
      });
    },
    /**-----------------------------------------------------------
     * Hàm bắt sự kiện khi click chọn đơn vị
     * Author: DTSang(31/08)
     */
    chooseDepartment(index) {
      if (index >= 0 && index <= this.departments.length) {
        this.item = this.departments[index];
        this.$emit("choosedDepartment", this.item.departmentId);
        this.keysearch = this.item.departmentName;
      }
    },
    /**-----------------------------------------------------------------
     * Hàm cập nhật dữ liệu khi value thay đổi
     * Author: DTSang(31/08)
     */
    setValue() {
      let flag = true;
      this.departments.forEach((department, index) => {
        if (department.departmentId == this.value) {
          this.chooseDepartment(index);
          flag = false;
        }
      });
      if (flag) {
        this.keysearch = "";
      }
    },
    /**---------------------------------------------------------------
     * Hàm sử lí sự kiện tìm kiếm đơn vị
     * Author: DTsang(31/08)
     */
    searchDepartment() {
      if (this.keysearch != "") {
        this.isShow = true;
        this.departments = [];
        this.options.forEach((department) => {
          if (
            department.departmentCode.includes(this.keysearch) ||
            department.departmentName.includes(this.keysearch)
          ) {
            this.departments.push(department);
            console.log(this.departments);
          }
        });
      } else {
        this.isShow = true;
      }
    },
    /**----------------------------------------------------------------------
     * Hàm check event khi click ra bên ngoài combobox
     * Author: DTSang(31/08)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        this.isShow = false;
        this.isRotate = true;
      }
    },
  },
  mounted() {
    document.addEventListener("click", this.close);
  },
};
</script>

<style>
.combobox {
  align-items: center;
  box-sizing: border-box;
  position: relative;
  width: 100%;
}
.show-combobox {
  display: block !important;
}
.flex {
  display: flex;
  width: 100%;
  height: 40px;
}
.combobox input {
  height: 100%;
  border: 1px solid #bbbbbb;
  border-radius: 4px;
  width: 100%;
  outline: none;
  padding-right: 40px;
  padding-left: 10px;
}
.width-100 {
  width: 100%;
}
.border-red {
  border-color: red;
}
.combobox input:focus {
  border-color: #2ca01c;
}
.btn-combobox {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -562px -357px;
  width: 16px;
  height: 16px;
  cursor: pointer;
  margin-left: 7px;
  margin-top: 7px;
}
.combobox-icon {
  margin-top: 1px;
  width: 38px;
  height: 38px;
  border-color: #e0e0e0;
  position: absolute;
  right: 2px;
  display: flex;
  justify-content: center;
  align-content: center;
}
.combobox-data {
  display: none;
  position: absolute;
  top: 34px;
  height: 10;
  background: #fff;
  width: 100%;
  padding: 4px 0;
  border: 1px solid #babec5;
  border-radius: 4px;
}
.combobox-data table {
  width: 100%;
  border-collapse: collapse;
}
.combobox-data table thead {
  background: #f4f5f8;
  font-weight: bolder;
}
.combobox-data table tr {
  height: 32px;
}
.combobox-data table tbody tr {
  text-align: center;
  cursor: pointer;
}
.combobox-data table tbody tr:hover {
  color: #35bf22;
  background-color: #ebedf0;
}
.combobox-active {
  color: #35bf22;
  background-color: #ebedf0;
}
</style>