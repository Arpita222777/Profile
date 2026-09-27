
var jobs = [
  { id:1, company:"Mobile First Corp", role:"React Native Developer", location:"Remote", type:"Full-time", salary:"$130,000 - $175,000", description:"Build cross-platform mobile applications using React Native. Work on products used by millions worldwide.", status:"not_applied" },
  { id:2, company:"WebFlow Agency", role:"Web Designer & Developer", location:"Los Angeles, CA", type:"Part-time", salary:"$80,000 - $120,000", description:"Create stunning web experiences for high-profile clients. Portfolio and modern design skills required.", status:"not_applied" },
  { id:3, company:"TechFlow", role:"Frontend Engineer", location:"San Francisco, CA", type:"Full-time", salary:"$140,000 - $180,000", description:"Lead the frontend development of our core SaaS product using React and Tailwind.", status:"not_applied" },
  { id:4, company:"CloudScale", role:"Backend Developer", location:"Seattle, WA", type:"Full-time", salary:"$150,000 - $190,000", description:"Develop scalable microservices using Node.js and AWS infrastructure.", status:"not_applied" },
  { id:5, company:"Designedly", role:"UI/UX Designer", location:"New York, NY", type:"Contract", salary:"$90,000 - $110,000", description:"Design user-centric interfaces for mobile and web applications.", status:"not_applied" },
  { id:6, company:"DataDrive", role:"Data Scientist", location:"Austin, TX", type:"Full-time", salary:"$135,000 - $170,000", description:"Apply machine learning models to solve complex business problems and drive growth.", status:"not_applied" },
  { id:7, company:"SecureNet", role:"Security Analyst", location:"Remote", type:"Full-time", salary:"$120,000 - $160,000", description:"Monitor and protect our cloud networks from vulnerabilities and threats.", status:"not_applied" },
  { id:8, company:"GrowthOps", role:"Marketing Specialist", location:"Chicago, IL", type:"Full-time", salary:"$70,000 - $95,000", description:"Manage digital marketing campaigns and optimize conversion funnels.", status:"not_applied" },
  { id:9, company:"AI Innovations", role:"ML Engineer", location:"Remote", type:"Full-time", salary:"$165,000 - $210,000", description:"Implement large language models for enterprise productivity tools.", status:"not_applied" },
  { id:10, company:"Pixel Perfect", role:"Senior UX Researcher", location:"London, UK", type:"Contract", salary:"$100,000 - $130,000", description:"Conduct user testing and accessibility audits for global e-commerce platforms.", status:"not_applied" },
  { id:11, company:"Cyber Shield", role:"DevSecOps Engineer", location:"Remote", type:"Full-time", salary:"$155,000 - $195,000", description:"Integrate security protocols into CI/CD pipelines and cloud infrastructure.", status:"not_applied" },
  { id:12, company:"GreenTech", role:"Full Stack Developer", location:"Portland, OR", type:"Full-time", salary:"$125,000 - $160,000", description:"Build renewable energy monitoring dashboards with React and Go.", status:"not_applied" }
];


var currentTab = "all";

function updateStatus(id, newStatus){

    for(var i = 0; i < jobs.length; i++){
        if(jobs[i].id == id){
            jobs[i].status = newStatus;
        }
    }

    showJobs();
}



function deleteJob(id){

    var temp = [];

    for(var i = 0; i < jobs.length; i++){
        if(jobs[i].id != id){
            temp.push(jobs[i]);
        }
    }

    jobs = temp;

    showJobs();
}


function showJobs(){

    var container = document.getElementById("jobsContainer");
    var emptyState = document.getElementById("emptyState");
    var countText = document.getElementById("countText");

    container.innerHTML = "";

    var total = jobs.length;
    var interview = 0;
    var rejected = 0;
    var shown = 0;

    // Count stats
    for(var i = 0; i < jobs.length; i++){
        if(jobs[i].status == "interview"){
            interview++;
        }
        if(jobs[i].status == "rejected"){
            rejected++;
        }
    }

    document.getElementById("statTotal").innerText = total;
    document.getElementById("statInterview").innerText = interview;
    document.getElementById("statRejected").innerText = rejected;

    // Display jobs
    for(var i = 0; i < jobs.length; i++){

        if(currentTab == "all" || jobs[i].status == currentTab){

            shown++;

            var statusColor = "bg-slate-700/50 text-slate-400";

            if(jobs[i].status == "interview"){
                statusColor = "bg-emerald-500/20 text-emerald-400";
            }

            if(jobs[i].status == "rejected"){
                statusColor = "bg-red-500/20 text-red-400";
            }

            var card = document.createElement("div");
            card.className = "job-card p-6 rounded-2xl relative";

            card.innerHTML =
            '<button onclick="deleteJob('+jobs[i].id+')" class="absolute top-6 right-6 text-slate-500 hover:text-red-500 transition-colors">' +
            '<svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">' +
            '<path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />' +
            '</svg></button>' +

            '<h3 class="text-xl font-bold">'+jobs[i].company+'</h3>' +
            '<p class="text-blue-400 font-semibold">'+jobs[i].role+'</p>' +

            '<div class="flex flex-wrap gap-x-4 gap-y-1 mt-3 text-sm text-slate-400">' +
            '<span>'+jobs[i].location+'</span> • ' +
            '<span>'+jobs[i].type+'</span> • ' +
            '<span>'+jobs[i].salary+'</span></div>' +

            '<div class="mt-3 inline-block px-3 py-1 rounded-lg text-xs font-bold uppercase tracking-widest '+statusColor+'">' +
            jobs[i].status.replace("_"," ") +
            '</div>' +

            '<p class="mt-4 text-slate-300 leading-relaxed">'+jobs[i].description+'</p>' +

            '<div class="mt-6 flex gap-3">' +
            '<button onclick="updateStatus('+jobs[i].id+', \'interview\')" class="btn btn-outline btn-success btn-sm px-6">INTERVIEW</button>' +
            '<button onclick="updateStatus('+jobs[i].id+', \'rejected\')" class="btn btn-outline btn-error btn-sm px-6">REJECTED</button>' +
            '</div>';

            container.appendChild(card);
        }
    }

    if(shown == 0){
        emptyState.classList.remove("hidden");
    } else {
        emptyState.classList.add("hidden");
    }

    if(currentTab == "all"){
        countText.innerText = shown + " jobs";
    } else {
        countText.innerText = shown + " of " + total + " jobs";
    }
}


var tabs = document.querySelectorAll('[role="tab"]');

for(var i = 0; i < tabs.length; i++){

    tabs[i].addEventListener("click", function(){

        for(var j = 0; j < tabs.length; j++){
            tabs[j].classList.remove("tab-active");
        }

        this.classList.add("tab-active");
        currentTab = this.getAttribute("data-tab");

        showJobs();
    });
}


showJobs();