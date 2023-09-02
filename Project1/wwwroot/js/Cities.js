let Governorate = ["Alexandria", "Aswan", "Asyut", "Beheira", "Beni Suef", "Cairo", "Dakahlia", "Damietta", "Faiyum", "Gharbia", "Giza", "Ismailia", "Kafr El Sheikh", "Luxor", "Matruh", "Minya", "Monufia", "New Valley", "North Sinai", "Port Said", "Qalyubia", "Qena", "Red Sea", "Sharqia", "Sohag", "South Sinai", "Suez"];
let citys = [
	["Alexandria", "Burj Al Arab", "New Burj Al Arab"],
	["Aswan", "New Aswan", "Drew", "Kom Ombo", "Nubian Victory", "Kalabsha", "Rhodesia", "Follicle", "Heptathlon", "Abu Simbel Tourist"],
	["Assiut", "New Assiut", "Qusiya", "Abnoub", "Abu Tig", "Ghanayem", "Slim Coast", "Badari", "Sadfa"],
	["Damanhour", "Kafr Al Dawar", "mature", "Edko", "Abu al Matamir", "Al Mahmoudia", "Rahmaniya", "Itay gunpowder", "Hosh Issa", "Shubrakhit", "Kom Hamada", "full moon", "Wadi Al Natroun", "New Nubaria", "Delengat", "Abu Homs"],
	["Beni Suef", "New Beni Suef", "Al Wasty", "Nasser", "Ehnasia", "BBA", "Al Fashn"],
	["Cairo"],
	["Kurdish", "Bani Ubayd", "Tami Al Amdid", "Shirbin", "Matareya", "Belqas", "Meet Salsil", "Gamasa", "Dimna locality", "we barber"],
	["Damietta", "New Damietta", "Ras El Bar", "Faraskour", "Kafr Saad", "Zarqa", "Cypress", "Al Rawda", "Ezbet Al Burj", "Mit Abu Ghalib"],
	["Al Fayyoum", "Singull", "Ibshway", "Yousef Alsedik", "Ibshway", "Itsa", "New Fayoum"],
	["Tanta", "Mahalla al Kobra", "Kafr al Zayat", "you asphalted", "Santa", "Tours", "Samanoud", "Basyoun"],
	["Giza", "Sheikh Zayed", "Hawamdiya", "Badrasheen", "El Saf", "Atfih", "Bawiti", "Al Qanater Facility", "Oseem", "Kerdasa", "Abu Al Nomros", "Ayyat", "Sixth of October"],
	["Ismailia", "Fayed", "Qantara East", "Kantara West", "Big Hill", "Abu Suwayr Al Mahatta", "New Qassaseen"],
	["Kafr El Sheikh", "Desouk", "Motobas", "Baltim", "Baltim resort", "Hamoul", "Bella", "Riyadh", "Sidi Salem", "Qaleen", "Sidi Ghazi", "Burullus Tower", "EL Modeer"],
	["Luxor", "New Luxor", "New Thebes", "Zinnia", "Bayadiya", "Qurna", "Armant", "Tod", "Esna"],
	["Marsa Matrouh", "Bathroom", "El Alamein", "Dabaa", "Grass", "Sidi Barrani", "Salloum", "Siwa"],
	["Minya", "New Minya", "Adwa", "Maghagha", "Beni Mazar", "Matay", "Samalout", "Intellectual City", "contorted", "Deir Mawas"],
	["Shebin al Kom", "Sadat City", "Menouf", "Sers Al Layan", "Ashmon", "Bagour", "Qwesna", "Berket al-Sabaa", "Talla", "Martyrs"],
	["Kharga", "Paris", "Mott", "Farafra", "tile"],
	["Arish", "Sheikh Zuwayed", "Rafah", "Bir Al Abd", "Alhassan", "sift"],
	["Port", "Port Fouad"],
	["Banha", "Qalyoub", "Shubra El Kheima", "Al Qanater Al Khayriyah", "Khanka", "Kafr Shukr", "Dark", "Kaha", "Transit", "Regard", "Shebin Al Kanater"],
	["Qena", "New Qena", "Abu Tisht", "Naga Hammadi", "Deshna", "Cessation", "Catch", "Naqada", "Shoot", "Farshoot"],
	["Hurghada", "Ras Ghareb", "Safaga", "Short", "Marsa Alam", "Shalateen", "Halayeb"],
	["Zagazig", "Tenth of Ramadan", "Minya al Qamh", "Belbeis", "Mashtoul Souk", "Qnayat", "Abu Hammad", "Consort", "Hehey", "Abu Kabir", "Faqous", "New Salhia", "Ibrahimia", "Deyerb Negm", "Kafr Saqr", "Saqr Sons", "Husseiniya", "San Stone Tribal", "Abu Omar Facility"],
	["Sohag", "New Sohag", "Akhmim", "New Akhmim", "Baliana", "Maragha", "Facility", "Dar es Salaam", "Girga", "Juhayna Al Gharbia", "I told him", "Tama", "Tahta"],
	["ELToor", "Sharm El Sheikh", "Dahab", "Nuweiba", "Taba", "Saint Catherine", "Abu Rudeis", "Abu Zeneima", "Ras Sidr"],
	["Suez"]
];
function city(obj,idd) {
	let val = obj.value;
	let index = Governorate.indexOf(val);
	let citylist = document.getElementById(idd);
	let cityarr = "<option>City</option>";
	if (index != -1) {
		for (let i = 0; i < citys[index].length; i++) {
			cityarr += "<option> " + citys[index][i] + " </option>";
		}
	}
	citylist.innerHTML = cityarr;
}