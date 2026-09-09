import React from 'react';
import {
  LayoutDashboard,
  GraduationCap,
  Users,
  School,
  BookOpen,
  CalendarCheck,
  FileCheck2,
  Receipt,
  Briefcase,
  BarChart3,
  ShieldAlert,
  DatabaseBackup,
  History,
  Settings,
  ChevronRight,
  ChevronLeft,
  Code2,
  FolderGit2
} from 'lucide-react';
import { ModuleKey } from '../../types';

interface SidebarProps {
  activeModule: ModuleKey;
  onSelectModule: (key: ModuleKey) => void;
  isCollapsed: boolean;
  onToggleCollapse: () => void;
  counts: {
    students: number;
    teachers: number;
    unpaidFees: number;
  };
}

interface NavGroup {
  groupTitle: string;
  items: {
    key: ModuleKey;
    label: string;
    icon: React.ReactNode;
    badge?: string | number;
    badgeColor?: string;
  }[];
}

export const Sidebar: React.FC<SidebarProps> = ({
  activeModule,
  onSelectModule,
  isCollapsed,
  onToggleCollapse,
  counts
}) => {
  const navGroups: NavGroup[] = [
    {
      groupTitle: 'الرئيسية',
      items: [
        {
          key: 'dashboard',
          label: 'لوحة التحكم',
          icon: <LayoutDashboard className="w-4 h-4 shrink-0" />
        }
      ]
    },
    {
      groupTitle: 'الشؤون التعليمية',
      items: [
        {
          key: 'students',
          label: 'شؤون الطلاب',
          icon: <GraduationCap className="w-4 h-4 shrink-0" />,
          badge: counts.students,
          badgeColor: 'bg-blue-900/60 text-blue-300'
        },
        {
          key: 'teachers',
          label: 'الكادر والمعلمون',
          icon: <Users className="w-4 h-4 shrink-0" />,
          badge: counts.teachers,
          badgeColor: 'bg-indigo-900/60 text-indigo-300'
        },
        {
          key: 'classes',
          label: 'الفصول والقاعات',
          icon: <School className="w-4 h-4 shrink-0" />
        },
        {
          key: 'subjects',
          label: 'المواد الدراسية',
          icon: <BookOpen className="w-4 h-4 shrink-0" />
        },
        {
          key: 'attendance',
          label: 'الحضور والغياب',
          icon: <CalendarCheck className="w-4 h-4 shrink-0" />
        },
        {
          key: 'exams',
          label: 'الامتحانات والدرجات',
          icon: <FileCheck2 className="w-4 h-4 shrink-0" />
        }
      ]
    },
    {
      groupTitle: 'الإدارة والمالية',
      items: [
        {
          key: 'finance',
          label: 'الرسوم والمحاسبة',
          icon: <Receipt className="w-4 h-4 shrink-0" />,
          badge: counts.unpaidFees > 0 ? `${counts.unpaidFees} متأخرة` : undefined,
          badgeColor: 'bg-amber-900/70 text-amber-300'
        },
        {
          key: 'hr',
          label: 'الموارد البشرية HR',
          icon: <Briefcase className="w-4 h-4 shrink-0" />
        },
        {
          key: 'reports',
          label: 'مركز التقارير',
          icon: <BarChart3 className="w-4 h-4 shrink-0" />
        }
      ]
    },
    {
      groupTitle: 'النظام والأمان',
      items: [
        {
          key: 'users',
          label: 'المستخدمون والصلاحيات',
          icon: <ShieldAlert className="w-4 h-4 shrink-0" />
        },
        {
          key: 'backup',
          label: 'النسخ الاحتياطي',
          icon: <DatabaseBackup className="w-4 h-4 shrink-0" />
        },
        {
          key: 'audit',
          label: 'سجل العمليات Audit',
          icon: <History className="w-4 h-4 shrink-0" />
        },
        {
          key: 'settings',
          label: 'إعدادات النظام',
          icon: <Settings className="w-4 h-4 shrink-0" />
        }
      ]
    },
    {
      groupTitle: 'الكود والمعمارية',
      items: [
        {
          key: 'solution',
          label: 'حزمة VB.NET & SQL',
          icon: <FolderGit2 className="w-4 h-4 shrink-0 text-cyan-400" />,
          badge: 'كود كامل',
          badgeColor: 'bg-cyan-950 border border-cyan-800 text-cyan-300'
        }
      ]
    }
  ];

  return (
    <aside
      id="desktop-sidebar"
      className={`h-full bg-slate-900/95 border-l border-slate-800 flex flex-col transition-all duration-300 z-30 shrink-0 select-none ${
        isCollapsed ? 'w-16' : 'w-64'
      }`}
    >
      {/* Sidebar Header with Collapse Toggle */}
      <div className="h-12 border-b border-slate-800 px-3 flex items-center justify-between">
        {!isCollapsed && (
          <span className="text-xs font-bold uppercase tracking-wider text-slate-400">
            أقسام النظام
          </span>
        )}
        <button
          onClick={onToggleCollapse}
          className={`p-1.5 rounded-lg bg-slate-800/80 hover:bg-slate-700 text-slate-300 hover:text-white transition-colors cursor-pointer ${
            isCollapsed ? 'mx-auto' : ''
          }`}
          title={isCollapsed ? 'توسيع القائمة (Expand)' : 'تصغير القائمة (Collapse)'}
        >
          {isCollapsed ? <ChevronLeft className="w-4 h-4" /> : <ChevronRight className="w-4 h-4" />}
        </button>
      </div>

      {/* Navigation List */}
      <div className="flex-1 overflow-y-auto py-2 px-2 space-y-4 custom-scrollbar">
        {navGroups.map((group, gIdx) => (
          <div key={gIdx} className="space-y-1">
            {!isCollapsed && (
              <div className="px-3 text-[10px] font-bold text-slate-400 uppercase tracking-wider">
                {group.groupTitle}
              </div>
            )}
            {group.items.map((item) => {
              const isActive = activeModule === item.key;
              return (
                <button
                  key={item.key}
                  onClick={() => onSelectModule(item.key)}
                  className={`w-full flex items-center gap-3 px-3 py-2 rounded-xl text-xs font-semibold transition-all cursor-pointer ${
                    isActive
                      ? 'bg-blue-600 text-white shadow-md shadow-blue-600/20'
                      : 'text-slate-300 hover:bg-slate-800/80 hover:text-slate-100'
                  } ${isCollapsed ? 'justify-center px-2' : ''}`}
                  title={isCollapsed ? item.label : undefined}
                >
                  <span className={isActive ? 'text-white' : 'text-slate-400 group-hover:text-slate-200'}>
                    {item.icon}
                  </span>

                  {!isCollapsed && (
                    <div className="flex-1 flex items-center justify-between text-right truncate">
                      <span className="truncate">{item.label}</span>
                      {item.badge !== undefined && (
                        <span
                          className={`text-[10px] font-mono px-1.5 py-0.5 rounded-md shrink-0 mr-1.5 font-bold ${
                            isActive ? 'bg-blue-800 text-white' : item.badgeColor || 'bg-slate-800 text-slate-300'
                          }`}
                        >
                          {item.badge}
                        </span>
                      )}
                    </div>
                  )}
                </button>
              );
            })}
          </div>
        ))}
      </div>

      {/* Footer Branding Info */}
      {!isCollapsed && (
        <div className="p-3 border-t border-slate-800/80 bg-slate-950/40 text-[11px] text-slate-400 text-center">
          <div className="font-bold text-slate-300">Edura Architecture</div>
          <div className="text-[10px] text-slate-400 font-mono">Clean Architecture + Dapper + SQL Server</div>
        </div>
      )}
    </aside>
  );
};
