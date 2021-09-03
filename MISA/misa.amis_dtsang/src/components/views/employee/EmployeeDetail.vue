<template>
  <div class="detail-wrapper">
    <div class="detail" :class="{ showDetail: isShow, zIndex3: isOpen }">
      <div class="detail-header">
        <div class="detail-header-left">
          <h4><b>Thông tin nhân viên</b></h4>
          <div class="check-customer">
            <div class="checkbox"></div>
            <p>Là khách hàng</p>
          </div>
          <div class="check-supplier">
            <div class="checkbox"></div>
            <p>Là nhà cung cấp</p>
          </div>
        </div>
        <div class="detail-header-right">
          <div
            class="btn-detail"
            data-toggle="tooltip"
            data-placement="top"
            title="Giúp"
          ></div>
          <div
            class="cancel"
            data-toggle="tooltip"
            data-placement="top"
            title="Đóng"
            @click="closeFormDetail"
          ></div>
        </div>
      </div>
      <ValidationObserver ref="form">
        <div class="detail-main">
          <div class="detail-main-top">
            <div class="item">
              <div class="item-left">
                <div style="width: 40%; height: 100%; padding-right: 8px">
                  <div class="label">Mã<span>*</span></div>
                  <ValidationProvider
                    tag="div"
                    class="vee"
                    rules="required"
                    name=" Mã nhân viên"
                    v-slot="{ errors }"
                  >
                    <input
                      type="text"
                      ref="EmployeeCode"
                      v-model="employee.employeeCode"
                      :class="{
                        'border-red': errors.length > 0 ? true : false,
                      }"
                      :title="errors[0]"
                    />
                  </ValidationProvider>
                </div>
                <div style="width: 60%; height: 100%">
                  <div class="label">Tên<span>*</span></div>
                  <ValidationProvider
                    tag="div"
                    class="vee"
                    rules="required"
                    name="Họ và tên nhân viên"
                    v-slot="{ errors }"
                  >
                    <input
                      type="text"
                      v-model="employee.fullName"
                      :class="{
                        'border-red': errors.length > 0 ? true : false,
                      }"
                      :title="errors[0]"
                    />
                  </ValidationProvider>
                </div>
              </div>
              <div class="item-right">
                <div style="width: 40%; height: 100%; padding-right: 8px">
                  <div class="label">Ngày sinh</div>
                  <div class="input" style="border: 1px solid #ccc">
                    <datepicker
                      style="width: 100%; height: 100%"
                      v-model="employee.dateOfBirth"
                      :format="'DD/MM/YYYY'"
                      :value-type="'YYYY-MM-DD'"
                    ></datepicker>
                  </div>
                </div>
                <div style="width: 50%; height: 100%">
                  <div class="label">Giới tính</div>
                  <div class="input" style="border: none">
                    <input
                      type="radio"
                      id="0"
                      name="gender"
                      v-model="employee.gender"
                      value="0"
                    />
                    <label class="margin0" for="0">Nữ</label><br />
                    <input
                      type="radio"
                      id="1"
                      name="gender"
                      v-model="employee.gender"
                      value="1"
                    />
                    <label class="margin0" for="1">Nam</label><br />
                    <input
                      type="radio"
                      id="2"
                      name="gender"
                      v-model="employee.gender"
                      value="2"
                    />
                    <label class="margin0" for="2">Khác</label>
                  </div>
                </div>
              </div>
            </div>
            <div class="item">
              <div class="item-left">
                <div style="width: 100%; height: 100%">
                  <div class="label">Đơn vị<span>*</span></div>
                  <Combobox
                    :value="employee.departmentId"
                    @choosedDepartment="updateDepartmentId"
                  />
                </div>
              </div>
              <div class="item-right">
                <div style="width: 60%; height: 100%; padding-right: 8px">
                  <div class="label">Số CMND</div>
                  <div class="input">
                    <input type="text" v-model="employee.identityNumber" />
                  </div>
                </div>
                <div style="width: 40%; height: 100%">
                  <div class="label">Ngày cấp</div>
                  <div class="input" style="border: 1px solid #ccc">
                    <datepicker
                      style="width: 100%"
                      v-model="employee.identityDate"
                      :format="'DD/MM/YYYY'"
                      :value-type="'YYYY-MM-DD'"
                    ></datepicker>
                  </div>
                </div>
              </div>
            </div>
            <div class="item">
              <div class="item-left">
                <div style="width: 100%">
                  <div class="label">Chức danh</div>
                  <div class="input">
                    <input type="text" v-model="employee.positionName" />
                  </div>
                </div>
              </div>
              <div class="item-right">
                <div style="width: 100%">
                  <div class="label">Nơi cấp</div>
                  <div class="input">
                    <input type="text" v-model="employee.identityPlace" />
                  </div>
                </div>
              </div>
            </div>
            <div class="space"></div>
          </div>
          <div class="detail-main-bottom">
            <div class="item">
              <div style="width: 100%">
                <div class="label">Địa chỉ</div>
                <div class="input">
                  <input type="text" v-model="employee.address" />
                </div>
              </div>
            </div>
            <div class="item">
              <div style="width: 100%; padding-right: 8px">
                <div class="label">ĐT di động</div>
                <div class="input">
                  <input type="text" v-model="employee.phoneNumber" />
                </div>
              </div>
              <div style="width: 100%; padding-right: 8px">
                <div class="label">ĐT Cố định</div>
                <div class="input">
                  <input type="text" v-model="employee.landlineNumber" />
                </div>
              </div>
              <div style="width: 100%; padding-right: 8px">
                <div class="label">Email</div>
                <ValidationProvider
                  tag="div"
                  class="vee"
                  rules="email"
                  name="Email"
                  v-slot="{ errors }"
                >
                  <input
                    type="text"
                    v-model="employee.email"
                    :class="{
                      'border-red': errors.length > 0 ? true : false,
                    }"
                    :title="errors[0]"
                  />
                </ValidationProvider>
              </div>
              <div style="width: 100%"></div>
            </div>
            <div class="item">
              <div style="width: 100%; padding-right: 8px">
                <div class="label">Tài khoản ngân hàng</div>
                <div class="input">
                  <input type="text" v-model="employee.accountNumber" />
                </div>
              </div>
              <div style="width: 100%; padding-right: 8px">
                <div class="label">Tên ngân hàng</div>
                <div class="input">
                  <input type="text" v-model="employee.bankName" />
                </div>
              </div>
              <div style="width: 100%; padding-right: 8px">
                <div class="label">Chi nhánh</div>
                <div class="input">
                  <input type="text" v-model="employee.bankBranch" />
                </div>
              </div>
              <div style="width: 100%"></div>
            </div>
            <div class="space"></div>
          </div>
        </div>
      </ValidationObserver>
      <div class="detail-footer">
        <div class="footer-main">
          <div class="footer-left">
            <Button
              typeBtn="cancel"
              textBtn="Hủy"
              @btnOnclick="comfirmAndCloseFormDetail"
            />
          </div>
          <div class="footer-right">
            <Button typeBtn="save" textBtn="Cất" @btnOnclick="SaveOnclick" />
            <Button
              typeBtn="saveAs"
              textBtn="Cất và Thêm"
              @btnOnclick="SaveOnclick"
            />
          </div>
        </div>
      </div>
    </div>
    <PopUpComfirm
      ref="PopUpComfirm"
      @closePopupConfirm="closePopup"
      @closeDetail="closeDetail"
      @comfirm="comfirm"
    />
    <PopUpWarning ref="PopUpWarning" @closePopupWarning="closePopup" />
  </div>
</template>

<script>
import Button from "../../base/BaseButton.vue";
import Combobox from "../../base/BaseCombobox.vue";
import PopUpComfirm from "../../base/BasePopUpComfirm.vue";
import PopUpWarning from "../../base/BasePopUpWarning.vue";
import axios from "axios";
export default {
  name: "EmployeeDetail",
  components: { Button, Combobox, PopUpComfirm, PopUpWarning },
  data() {
    return {
      employee: {}, // lưu nhân viên đang được bind trên form
      typeMode: "", // lưu trạng thái của thao tác sửa hay thêm mới
      isShow: false, // biến để mở form detail
      isOpen: false,
      typeBtn: "", // lưu trạng thái của button đang hoạt động
      countChange: 0,
    };
  },
  methods: {
    /**
     * Hàm bắt sự kiện từ cha để mở form Detail
     * Author: Dtsang(31/08)
     */
    showEmployeeDetail(data, type) {
      this.employee = data;
      this.typeMode = type;
      if (this.typeMode == "add") {
        this.getNewEmployeeCode();
        this.isShow = true;
        this.$nextTick(() => this.$refs.EmployeeCode.focus());
      } else if (this.typeMode == "edit") {
        this.isShow = true;
        this.$nextTick(() => this.$refs.EmployeeCode.focus());
      } else if (this.typeMode == "dup") {
        this.getNewEmployeeCode();
        this.isShow = true;
        this.$nextTick(() => this.$refs.EmployeeCode.focus());
      }
    },
    /**
     * Hàm tự động lấy mã nhân viên mới
     * Author:DTsang(31/08)
     */
    getNewEmployeeCode() {
      let self = this;
      axios
        .get("https://localhost:5001/api/v1/Employees/NewEmployeeCode")
        .then((response) => {
          if (this.typeMode == "add") {
            let newE = {};
            newE.employeeCode = response.data.data;
            self.employee = newE;
          } else {
            self.employee.employeeCode = response.data.data;
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },
    /**
     * Sự kiện khi bấm vào nút Hủy trên form detail
     * Author: DTSang(01/09)
     */
    comfirmAndCloseFormDetail(type) {
      if (type == "cancel") {
        debugger; // eslint-disable-line
        if (
          (this.typeMode == "add" && this.countChange > 2) ||
          (this.typeMode == "edit" && this.countChange > 3)
        ) {
          debugger; // eslint-disable-line
          //this.typeBtn = type;
          this.$refs.PopUpComfirm.openPopupConfirm();
          this.isOpen = true;
        }
      }
    },
    /**
     * Sự kiện bấm nút X ---- cần kiểm tra nếu form đã thay đổi thì đưa ra cảnh báo có lưu hay không
     * Author: DtSang(31/08)
     */
    closeFormDetail() {
      this.$emit("closeForm");
      this.isShow = false;
      this.countChange = 0;
      this.$refs.form.reset();
    },
    /**
     * Sự kiện đóng pop up xác nhận khi bấm vào Hủy trong form pop up
     * Author: DTSang(31/08)
     */
    closePopup() {
      this.isOpen = false;
    },
    /**
     * Sự kiện đóng pop up xác nhận và đóng form detail
     * Author: DTSang(31/08)
     */
    closeDetail() {
      this.countChange = 0;
      this.isOpen = false;
      this.closeFormDetail();
    },
    /**
     * Sự kiện khi bấm xác nhận trên pop up bắt đầu lưu nhân viên
     * Author: DTsang(31/08)
     */
    comfirm() {
      this.$refs.form.validate().then((success) => {
        if (!success) {
          this.$refs.PopUpWarning.openPopupWarrning();
          this.isOpen = true;
        } else {
          this.btnSaveOnclick();
        }
      });
    },
    /**
     * Sự kiện click vào các button để lưu nhân viên trong form Detail
     * Author: DTSang(31/08)
     */
    SaveOnclick(type) {
      this.$refs.form.validate().then((success) => {
        if (!success) {
          this.$refs.PopUpWarning.openPopupWarrning();
          this.isOpen = true;
        } else {
          if (type == "save") {
            this.btnSaveOnclick();
          } else if (type == "saveAs") {
            this.btnSaveAsOnclick();
          }
        }
      });
    },
    /**
     * Sự kiện click vào nút Cất
     * Author: DTSAng(31/08)
     */
    btnSaveOnclick() {
      if (this.typeMode == "add" || this.typeMode == "dup") {
        this.addEmployee(this.employee);
        this.closeFormDetail();
      } else if (this.typeMode == "edit") {
        this.editEmployee(this.employee.employeeId, this.employee);
        this.closeFormDetail();
      }
    },
    /**
     * Sự kiện bấm vào nút Cất và thêm
     * Author: DTSang(31/08)
     */
    btnSaveAsOnclick() {
      if (this.typeMode == "add" || this.typeMode == "dup") {
        this.addEmployee(this.employee);
        this.$refs.form.reset();
        this.$nextTick(() => this.$refs.EmployeeCode.focus());
        // }
      } else if (this.typeMode == "edit") {
        this.editEmployee(this.employee.employeeId, this.employee);
        this.$refs.form.reset();
        this.$nextTick(() => this.$refs.EmployeeCode.focus());
        this.typeMode = "add";
      }
    },
    /**
     * Hàm thêm nhân viên mới
     * Author: DTsang(31/08)
     */
    addEmployee(value) {
      let self = this;
      axios
        .post("https://localhost:5001/api/v1/Employees", value)
        .then((response) => {
          console.log(response.data);
          self.$toast.success(response.data.userMsg, {
            timeout: 3000,
          });
          self.$emit("reloadTable");
          this.employee = {};
          this.getNewEmployeeCode();
          this.countChange = 0;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    /**
     * Hàm sửa thông tin nhân viên
     * Author: DTSang(31/08)
     */
    editEmployee(id, value) {
      let self = this;
      axios
        .put(`https://localhost:5001/api/v1/Employees/${id}`, value)
        .then((response) => {
          console.log(response.data);
          self.$toast.success(response.data.userMsg, {
            timeout: 3000,
          });
          self.$emit("reloadTable");
          this.employee = {};
          this.getNewEmployeeCode();
          this.countChange = 0;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    /**
     * Cập nhật departmentId từ form
     * Author: Dtsang(31/08)
     */
    updateDepartmentId(data) {
      this.employee.departmentId = data;
      this.countChange += 1;
    },
  },
  watch: {
    /**
     * Hàm lắng nghe sự thay đổi của employee để xem form đã thay đổi hay không 
     * Author: DTSang(01/09)
     */
    employee: function () {
      this.countChange += 1;
    },
  },
};
</script>

<style scoped>
.detail-wrapper{
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
}
.detail {
  width: 900px;
  height: 625px;
  display: none;
  background-color: #fff;
  position: absolute;
  margin: auto;
  z-index: 5;
  font-family: Misa-Regular;
}
.showDetail {
  display: block;
}
.zIndex3 {
  z-index: 3 !important;
}
.detail-header {
  width: 100%;
  height: 15%;
  display: flex;
  justify-content: space-between;
}
.detail-header-left {
  padding-left: 30px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.check-customer,
.check-supplier {
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 0 15px;
}
.checkbox {
  width: 22px;
  height: 22px;
  border: 1px solid #ccc;
  margin-right: 10px;
}
p,
h4 {
  margin: 0;
}
.detail-header-right {
  margin: 8px;
  display: flex;
  justify-content: center;
  /* align-items: center; */
}
.btn-detail {
  width: 24px;
  height: 24px;
  margin-right: 6px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -89px -145px;
}
.cancel {
  width: 24px;
  height: 24px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -145px -145px;
}
.detail-main {
  width: 100%;
  height: 70%;
}
.detail-main-top {
  width: 100%;
  height: 50%;
}
.detail-main-bottom {
  width: 100%;
  height: 50%;
}
.item {
  width: 100%;
  height: 30%;
  padding: 0 50px 0 30px;
  display: flex;
}
.item .item-left {
  width: 50%;
  height: 100%;
  display: flex;
  padding-right: 15px;
}
.item .item-right {
  width: 50%;
  height: 100%;
  display: flex;
  padding-left: 15px;
}
.label {
  text-align: left;
  font-weight: bold;
  color: #000;
}
.label span {
  color: red;
}
.margin0 {
  margin: 0;
}
.vee {
  height: 50%;
  width: 100%;
}
.input {
  width: 100%;
  height: 50%;
  border-radius: 4px;
  display: flex;
  justify-content: center;
  align-items: center;
}
input {
  width: 100%;
  height: 100%;
  border: 1px solid #ccc;
  border-radius: 4px;
  outline: none;
  padding-left: 10px;
}
input:focus {
  border-color: #35bf22;
}
input:blur {
  border-color: #ccc;
}
.border-red {
  border-color: red;
}
input[type="radio"] {
  border: 0px;
  width: 100%;
  height: 24px;
}
input[type='radio']:checked:after {
  width: 15px;
  height: 15px;
  border-radius: 15px;
  top: 2px;
  left: 10px;
  position: relative;
  background-color: #2ca01c;
  content: '';
  display: inline-block;
  visibility: visible;
}
.space {
  width: 100%;
  height: 10%;
}
.detail-footer {
  width: 100%;
  height: 15%;
  padding: 0 30px;
}
.footer-main {
  width: 100%;
  height: 100%;
  border-top: 1px solid #ccc;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
</style>
